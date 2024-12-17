import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { MatCard } from '@angular/material/card';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import {
  ActivatedRoute,
  Router,
  RouterLink,
  RouterLinkActive,
} from '@angular/router';
import { AccountService } from '../../../core/services/account.service';
import { initializeApp } from 'firebase/app';
import { getAuth, GoogleAuthProvider, signInWithPopup } from 'firebase/auth';
import { environment } from '../../../../environments/environment';
import { CommonModule } from '@angular/common';
import { SnackbarService } from '../../../core/services/snackbar.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    RouterLink,
    RouterLinkActive,
    ReactiveFormsModule,
    MatCard,
    MatFormField,
    MatInput,
    MatLabel,
    MatButton,
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent {
  private fb = inject(FormBuilder);
  private accountService = inject(AccountService);
  private router = inject(Router);
  private activatedRoute = inject(ActivatedRoute);
  private snack = inject(SnackbarService);
  returnUrl = '/shop';

  constructor() {
    const url = this.activatedRoute.snapshot.queryParams['returnUrl'];
    if (url) this.returnUrl = url;
  }

  loginForm = this.fb.group({
    email: [''],
    password: [''],
  });

  onSubmit() {
    this.accountService.login(this.loginForm.value).subscribe({
      next: () => {
        this.accountService.getUserInfo().subscribe();
        this.router.navigateByUrl(this.returnUrl);
      },
    });
  }

  // Firebase Google Sign-In
  signInWithGoogle() {
    const app = initializeApp(environment.firebaseConfig); // Initialize Firebase app with firebaseConfig
    const auth = getAuth(app);
    const provider = new GoogleAuthProvider();
    provider.addScope('profile');

    signInWithPopup(auth, provider)
      .then((result) => {
        // Lấy thông tin người dùng sau khi đăng nhập thành công
        const user = result.user;
        console.log('Logged in as:', user);

        const displayName = user.displayName || '';
        const nameParts = displayName.split(' ');
        const firstName = nameParts[0];
        const lastName = nameParts.slice(1).join(' ');
        const email = user.email;
        const password = 'GoogleAuth1!';

        this.accountService
          .register({ firstName, lastName, email, password })
          .subscribe({
            next: () => {
              // Đăng ký thành công => Đăng nhập
              this.accountService.login({ email, password }).subscribe({
                next: () => {
                  this.accountService.login({ email, password }).subscribe({
                    next: () => {
                      this.accountService.getUserInfo().subscribe();
                      this.router.navigateByUrl(this.returnUrl);
                    },
                  });
                },
                error: (loginError) => {
                  console.error('Login failed:', loginError);
                },
              });
            },
            error: (registerError) => {
              // Tài khoản đã tồn tại => Chuyển sang đăng nhập
              this.accountService.login({ email, password }).subscribe({
                next: () => {
                  this.accountService.login({ email, password }).subscribe({
                    next: () => {
                      this.accountService.getUserInfo().subscribe();
                      this.router.navigateByUrl(this.returnUrl);
                    },
                  });
                },
                error: (loginError) => {
                  console.error('Login failed:', loginError);
                },
              });
            },
          });
      })
      .catch((error) => {
        console.error('Error signing in with Google:', error);
      });
  }

  onForgotPassword() {
    const email = this.loginForm.get('email')?.value?.trim();
    if (!email) {
      this.snack.error('Please enter email!');
      return;
    }
    this.accountService.getForgotPassword(email).subscribe({
      next: (response) => {
        console.log('API Response:', response);
        this.snack.success(response);
      },
      error: (errors) => {
        this.snack.error(errors.error || 'An error occurred');
      }
    })
  }
}
