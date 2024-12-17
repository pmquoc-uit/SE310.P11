import { Component, inject } from '@angular/core';
import { AccountService } from '../../core/services/account.service';
import { TextInputComponent } from '../../shared/components/text-input/text-input.component';
import { MatCard, MatCardModule } from '@angular/material/card';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { CommonModule, JsonPipe } from '@angular/common';
import {
  FormBuilder,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatFormField, MatLabel, MatError } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { SnackbarService } from '../../core/services/snackbar.service';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { MatIcon } from '@angular/material/icon';
import { User } from '../../shared/models/user';
import { MatProgressSpinner } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [
    MatTabsModule,
    MatTableModule,
    RouterLink,
    RouterLinkActive,
    ReactiveFormsModule,
    MatCard,
    MatFormField,
    MatLabel,
    MatInput,
    MatButton,
    JsonPipe,
    MatError,
    TextInputComponent,
    MatButton,
    MatIcon,
    CommonModule,
    FormsModule,
    MatProgressSpinner
  ],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss',
})
export class ProfileComponent {
  private fb = inject(FormBuilder);
  private accountService = inject(AccountService);
  private router = inject(Router);
  private snack = inject(SnackbarService);
  validationErrors?: string[];
  myUser: User = {
    firstName: '',
    lastName: '',
    email: '',
    address: { line1: '', city: '', state: '', country: '', postalCode: '' },
    roles: [],
  };
  isGoogle: boolean = false;
  isLoading = false;


  ngOnInit() {
    // Khi nhận được response, ép kiểu cho nó là User
    this.accountService.getUserInfo().subscribe({
      next: (response) => {
        // Ép kiểu response thành User
        this.myUser = response as User;
        console.log('Fetched user: ', this.myUser);
      },
      error: (error) => {
        console.error('Error fetching user info', error);
      },
    });

    this.accountService.getGoogleState().subscribe({
      next: (response) => {
        this.isGoogle = response.isGoogle.valueOf();
        console.log('Fetched googleState: ', this.isGoogle);
      },
      error: (error) => {
        console.error('Error fetching user info', error);
      },
    });
  }
  isEditing: boolean = false; // Trạng thái để bật/tắt chế độ chỉnh sửa

  // Hàm bật/tắt chế độ chỉnh sửa
  toggleEditMode() {
    this.isEditing = !this.isEditing; // Chuyển đổi chế độ chỉnh sửa
    console.log('isEditing:', this.isEditing); // Log ra giá trị của isEditing
  }

  saveChanges() {
    const payload = {
      firstName: this.myUser.firstName,
      lastName: this.myUser.lastName,
    };
    console.log(payload)
    this.isLoading = true;
    this.accountService.updateUserInfo(payload).subscribe({
      next: (response) => {
        this.isLoading = false;
        this.snack.success(response);
        this.isEditing = false;
        this.accountService.getUserInfo().subscribe();
        // this.passwordForm.reset();
        // window.location.reload()
      },
      error: (errors) => {
        this.snack.error(errors.error || 'An error occurred');
        this.isLoading = false;
      },
    });

    // Tạm thời chưa thực hiện logic lưu dữ liệu
    // alert('Changes saved!');
    // this.isEditing = false;
  }

  passwordForm = this.fb.group({
    currentPassword: ['', Validators.required],
    newPassword: ['', Validators.required],
    confirmPassword: ['', Validators.required],
  });

  onUpdate() {
    const currentPassword = this.passwordForm.get('currentPassword')?.value;
    const newPassword = this.passwordForm.get('newPassword')?.value;
    const confirmPassword = this.passwordForm.get('confirmPassword')?.value;
    if (newPassword !== confirmPassword) {
      console.log(newPassword, confirmPassword)
      this.snack.error('Passwords do not match!');
      return;
    } else {
      const payload = {
        currentPassword: currentPassword,
        newPassword: newPassword,
      };
      console.log(payload)
      this.isLoading = true;
      this.accountService.changePassword(payload).subscribe({
        next: (response) => {
          this.isLoading = false;
          this.snack.success(response);
          // this.passwordForm.reset();
          window.location.reload()
        },
        error: (errors) => {
          this.snack.error(errors.error || 'An error occurred');
          this.isLoading = false;
        },
      });
    }
  }

  // dateFormats = ['MM/DD/YYYY', 'DD/MM/YYYY', 'YYYY-MM-DD'];
  // myProfile = {
  //   firstName: 'Pavel',
  //   lastName: 'Salauyou',
  //   username: '@pavel.salauyou',
  //   email: 'pavel.salauyou@example.com',
  //   jobTitle: 'Team Lead',
  //   bio: 'Senior Angular Developer',
  //   phoneNumber: '+1(23)4567890',
  //   preferences: {
  //     language: {
  //       code: 'us',
  //       name: 'English (United States)',
  //     },
  //     dateFormat: 'DD/MM/YYYY',
  //     automaticTimeZone: {
  //       name: 'GMT+04:00',
  //       isEnabled: true,
  //     },
  //   },
  //   address: {
  //     country: 'United Kingdom',
  //     city: 'London',
  //     postalCode: 'WC36 4UF',
  //     street: 'Broadway',
  //     building: 93,
  //     apartment: 1,
  //   },
  // };
}
