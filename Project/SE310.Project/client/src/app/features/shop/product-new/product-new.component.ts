import { CommonModule } from '@angular/common';
import { Component, Inject, inject } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatButton } from '@angular/material/button';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { MatSelectModule } from '@angular/material/select';
import { TextInputComponent } from '../../../shared/components/text-input/text-input.component';
import { ShopService } from '../../../core/services/shop.service';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { Product } from '../../../shared/models/product';
import { MatProgressSpinner } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-product-new',
  standalone: true,
  imports: [
    MatSelectModule,
    MatButton,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    TextInputComponent,
    MatDialogModule,
    MatProgressSpinner
  ],
  templateUrl: './product-new.component.html',
  styleUrl: './product-new.component.scss',
})
export class ProductNewComponent {
  private shopService = inject(ShopService);
  private fb = inject(FormBuilder);
  private snack = inject(SnackbarService);
  validationErrors?: string[];
  newForm: FormGroup;
  imagePreview: string | null = 'https://placehold.co/800.png';
  isLoading = false;

  constructor(
    private dialogRef: MatDialogRef<ProductNewComponent>,
    @Inject(MAT_DIALOG_DATA)
    public data: { product: Product }
  ) {
    this.newForm = this.fb.group({
      id: [0],
      name: ['', Validators.required],
      description: ['', Validators.required],
      price: ['', [Validators.required, Validators.min(0.01)]],
      quantityInStock: ['', [Validators.required, Validators.min(0)]],
      type: ['', Validators.required],
      brand: ['', Validators.required],
      pictureUrl: ['', Validators.required],
    });
  }

  ensureMinValue(controlName: string, minValue: number): void {
    const control = this.newForm.get(controlName);
    if (control && control.value !== null && control.value < minValue) {
      control.setValue(minValue, { emitEvent: false }); // Đặt giá trị tối thiểu
    }
  }

  onSubmit() {
    const updatedProduct = this.newForm.value;
    console.log(updatedProduct);
    this.isLoading = true;
    this.shopService.newProduct(updatedProduct).subscribe({
      next: (response: string) => {
        try {
          // Kiểm tra xem response có phải là JSON hay không
          const jsonResponse = JSON.parse(response);
          if (jsonResponse && jsonResponse.id) {
            // Xử lý khi backend trả về JSON (ví dụ từ CreatedAtAction)
            console.log('Product created successfully:', jsonResponse);
            this.snack.success('Product created successfully!');
            this.dialogRef.close(true); // Gửi sản phẩm đã cập nhật về component cha
            this.isLoading = false;
          }
        } catch (e) {
          // Xử lý khi backend trả về plain text (ví dụ lỗi hoặc thông báo)
          console.log('Text response:', response);
          this.snack.error(response);
          this.isLoading = false;
        }
      },
      error: (error) => {
        console.error('Error creating product:', error);
        this.snack.error('Added failed!');
      },
    });
  }

  onFileSelected(event: Event): void {
    const file = (event.target as HTMLInputElement).files?.[0];
    if (file) {
      const formData = new FormData();
      formData.append('file', file);

      // Add extra Cloudinary options if needed
      formData.append('upload_preset', 'your_preset'); // Replace with your Cloudinary preset

      this.isLoading = true;
      // Call the backend API to upload the file
      this.shopService.uploadPhoto(formData).subscribe({
        next: (response) => {
          this.isLoading = false;
          this.newForm.patchValue({ pictureUrl: response.secureUrl });
          this.imagePreview = response.secureUrl; // Display uploaded image
          this.snack.success('Photo upload successful');
        },
        error: (error) => {
          this.isLoading = false;
          console.error('Photo upload failed:', error);
          this.snack.error('Photo upload failed');
          // this.validationErrors = error?.error || ['Unknown error occurred'];
        },
      });
    }
  }
}
