import { CommonModule } from '@angular/common';
import { Component, inject, Inject } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { Product } from '../../../shared/models/product';
import { ShopService } from '../../../core/services/shop.service';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { TextInputComponent } from '../../../shared/components/text-input/text-input.component';
import { MatProgressSpinner } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-product-edit',
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
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.scss'],
})
export class ProductEditComponent {
  private shopService = inject(ShopService);
  private fb = inject(FormBuilder);
  private snack = inject(SnackbarService);
  validationErrors?: string[];
  editForm: FormGroup;
  imagePreview: string | null = 'https://placehold.co/800.png';
  isLoading = false;

  constructor(
    private dialogRef: MatDialogRef<ProductEditComponent>,
    @Inject(MAT_DIALOG_DATA)
    public data: { product: Product }
  ) {
    const product = data.product;
    this.imagePreview = product.pictureUrl;
    this.editForm = this.fb.group({
      id: [product.id, Validators.required],
      name: [{ value: product.name, disabled: true }, Validators.required],
      description: [
        { value: product.description, disabled: true },
        Validators.required,
      ],
      price: [
        { value: product.price, disabled: true },
        [Validators.required, Validators.min(0.01)],
      ],
      quantityInStock: [
        { value: product.quantityInStock, disabled: true },
        [Validators.required, Validators.min(0)],
      ],
      type: [{ value: product.type, disabled: true }, Validators.required],
      brand: [{ value: product.brand, disabled: true }, Validators.required],
      pictureUrl: [
        { value: product.pictureUrl, disabled: true },
        Validators.required,
      ],
    });
  }

  ensureMinValue(controlName: string, minValue: number): void {
    const control = this.editForm.get(controlName);
    if (control && control.value !== null && control.value < minValue) {
      control.setValue(minValue, { emitEvent: false }); // Đặt giá trị tối thiểu
    }
  }

  nonEditing = true;
  isEditing = false;
  toggleEdit() {
    if (this.isEditing) {
      // Nếu đang ở chế độ chỉnh sửa, thực hiện lưu dữ liệu
      const updatedProduct = this.editForm.value; // Lấy dữ liệu từ form
      const productId = this.data.product.id; // Lấy ID sản phẩm từ dữ liệu gốc

      this.isLoading = true;
      this.shopService.updateProduct(productId, updatedProduct).subscribe({
        next: (response) => {
          console.log('Update successful:', response); // Phản hồi từ server
          this.snack.success('Update successful');
          this.isEditing = false; // Chỉ chuyển trạng thái nếu cập nhật thành công
          this.editForm.disable(); // Vô hiệu hóa form sau khi lưu
          this.dialogRef.close(updatedProduct); // Gửi sản phẩm đã cập nhật về component cha
          this.isLoading = false;
        },
        error: (error) => {
          console.error('Update failed:', error); // Log lỗi nếu có
          this.snack.error('Update failed');
          this.isLoading = false;
          // this.validationErrors = error?.error || ['Unknown error occurred'];
        },
      });
    } else {
      // Chuyển sang chế độ chỉnh sửa
      this.isEditing = true;
      this.editForm.enable();
    }
  }

  // onSubmit() {
  //   const productId = this.data.product.id;
  //   const updatedProduct = this.editForm.value;

  //   this.shopService.updateProduct(productId, updatedProduct).subscribe({
  //     next: (response) => {
  //       console.log('Update successful:', response);
  //       this.dialogRef.close(true);
  //     },
  //     error: (error) => {
  //       console.error('Update failed:', error);
  //       this.validationErrors = error?.error || ['Unknown error occurred'];
  //     },
  //   });
  // }


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
          this.editForm.patchValue({ pictureUrl: response.secureUrl });
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
