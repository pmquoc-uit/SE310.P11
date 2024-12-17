import { CurrencyPipe, DatePipe } from '@angular/common';
import {
  ChangeDetectorRef,
  Component,
  Inject,
  inject,
  OnInit,
} from '@angular/core';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import {
  MatLabel,
  MatSelectChange,
  MatSelectModule,
} from '@angular/material/select';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { MatTooltipModule } from '@angular/material/tooltip';
import { RouterLink } from '@angular/router';
import { AdminService } from '../../core/services/admin.service';
import { DialogService } from '../../core/services/dialog.service';
import { Order } from '../../shared/models/order';
import { OrderParams } from '../../shared/models/orderParams';
import { ShopService } from '../../core/services/shop.service';
import { Pagination } from '../../shared/models/pagination';
import { Product } from '../../shared/models/product';
import { ShopParams } from '../../shared/models/shopParams';
import {
  MatListOption,
  MatSelectionList,
  MatSelectionListChange,
} from '@angular/material/list';
import { FiltersDialogComponent } from '../shop/filters-dialog/filters-dialog.component';
import {
  MAT_DIALOG_DATA,
  MatDialog,
  MatDialogRef,
} from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import { MatMenu, MatMenuTrigger } from '@angular/material/menu';
import { EmptyStateComponent } from '../../shared/components/empty-state/empty-state.component';
import { ProductEditComponent } from '../shop/product-edit/product-edit.component';
import { ProductNewComponent } from '../shop/product-new/product-new.component';
import { SnackbarService } from '../../core/services/snackbar.service';
import { MatCard, MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [
    MatTableModule,
    MatPaginatorModule,
    MatButton,
    MatIcon,
    MatSelectModule,
    DatePipe,
    CurrencyPipe,
    MatLabel,
    MatTooltipModule,
    MatTabsModule,
    RouterLink,
    FormsModule,
    MatSelectionList,
    MatMenuTrigger,
    MatMenu,
    MatListOption,
    EmptyStateComponent,
    MatButton,
  ],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.scss',
})
export class AdminComponent implements OnInit {
  displayedColumns: string[] = [
    'id',
    'buyerEmail',
    'orderDate',
    'total',
    'status',
    'action',
  ];
  dataSource = new MatTableDataSource<Order>([]);
  private adminService = inject(AdminService);
  private dialogService = inject(DialogService);
  orderParams = new OrderParams();
  totalItems = 0;
  statusOptions = [
    'All',
    'PaymentReceived',
    'PaymentMismatch',
    'Refunded',
    'Pending',
  ];

  ngOnInit(): void {
    this.loadOrders();
    this.initialiseShop();
  }

  loadOrders() {
    this.adminService.getOrders(this.orderParams).subscribe({
      next: (response) => {
        if (response.data) {
          this.dataSource.data = response.data;
          this.totalItems = response.count;
        }
      },
    });
  }

  onPageChange(event: PageEvent) {
    this.orderParams.pageNumber = event.pageIndex + 1;
    this.orderParams.pageSize = event.pageSize;
    this.loadOrders();
  }

  onFilterSelect(event: MatSelectChange) {
    this.orderParams.filter = event.value;
    this.orderParams.pageNumber = 1;
    this.loadOrders();
  }

  async openConfirmDialog(id: number) {
    const confirmed = await this.dialogService.confirm(
      'Confirm refund',
      'Are you sure you want to issue this refund? This cannot be undone'
    );

    if (confirmed) this.refundOrder(id);
  }

  refundOrder(id: number) {
    this.adminService.refundOrder(id).subscribe({
      next: (order) => {
        this.dataSource.data = this.dataSource.data.map((o) =>
          o.id === id ? order : o
        );
      },
    });
  }

  //Product Managerment
  productDisplayedColumns: string[] = [
    'id',
    'name',
    'description',
    'price',
    'type',
    'brand',
    'quantityInStock',
    'pictureUrl',
    'action',
  ];
  productDataSource = new MatTableDataSource<Product>([]);
  private shopService = inject(ShopService);
  private shopDialogService = inject(MatDialog);
  private deletedialog = inject(MatDialog);
  private cdr = inject(ChangeDetectorRef);
  private snack = inject(SnackbarService);
  products?: Pagination<Product>;
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low-High', value: 'priceAsc' },
    { name: 'Price: High-Low', value: 'priceDesc' },
  ];
  shopParams = new ShopParams();
  pageSizeOptions = [5, 10, 15, 20];

  initialiseShop() {
    this.shopService.getTypes();
    this.shopService.getBrands();
    this.getProducts();
  }

  resetFilters() {
    this.shopParams = new ShopParams();
    this.getProducts();
  }

  getProducts() {
    this.shopService.getProducts(this.shopParams).subscribe({
      next: (
        response //this.products = response,
      ) => {
        this.products = response;
        this.productDataSource.data = response.data;
      },
      error: (error) => console.error(error),
    });
  }

  onSearchChange() {
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  handlePageEvent(event: PageEvent) {
    this.shopParams.pageNumber = event.pageIndex + 1;
    this.shopParams.pageSize = event.pageSize;
    this.getProducts();
  }

  onSortChange(event: MatSelectionListChange) {
    const selectedOption = event.options[0];
    if (selectedOption) {
      this.shopParams.sort = selectedOption.value;
      this.shopParams.pageNumber = 1;
      this.getProducts();
    }
  }

  openFiltersDialog() {
    const dialogRef = this.shopDialogService.open(FiltersDialogComponent, {
      minWidth: '500px',
      data: {
        selectedBrands: this.shopParams.brands,
        selectedTypes: this.shopParams.types,
      },
    });
    dialogRef.afterClosed().subscribe({
      next: (result) => {
        if (result) {
          this.shopParams.brands = result.selectedBrands;
          this.shopParams.types = result.selectedTypes;
          this.shopParams.pageNumber = 1;
          this.getProducts();
        }
      },
    });
  }

  //Dialog for edit product
  openEditDialog(dialogProduct: Product) {
    const dialogRef = this.shopDialogService.open(ProductEditComponent, {
      width: '500px',
      data: { product: dialogProduct }, // Gửi dữ liệu sản phẩm vào dialog
    });

    dialogRef.afterClosed().subscribe((updatedProduct: Product | undefined) => {
      if (updatedProduct) {
        this.initialiseShop();
        // console.log(this.shopService.brands)
        // this.cdr.detectChanges();
        // Cập nhật sản phẩm trong danh sách
        // const index = this.productDataSource.data.findIndex((p) => p.id === updatedProduct.id)
        // if (index !== -1) {
        //   this.productDataSource.data[index] = { ...this.productDataSource.data[index], ...updatedProduct };
        //   this.productDataSource = new MatTableDataSource(this.productDataSource.data);  // Tạo lại MatTableDataSource
        // }
      }
    });
  }

  //Dialog for new product
  openNewDialog() {
    const dialogRef = this.shopDialogService.open(ProductNewComponent, {
      width: '500px',
      data: { product: null },
    });

    dialogRef.afterClosed().subscribe((addedProduct: boolean) => {
      if (addedProduct) {
        this.initialiseShop();
      }
    });
  }

  openDeleteDialog(productId: number): void {
    const dialogRef = this.deletedialog.open(DeleteDialogContent, {
      width: '400px',
      data: { productId }, // Truyền id sản phẩm vào dialog
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.deleteProduct(productId);
      }
    });
  }

  deleteProduct(id: number) {
    this.shopService.deleteProduct(id).subscribe({
      next: (
        response //this.products = response,
      ) => {
        this.snack.success(response);
        this.initialiseShop();
      },
      error: (error) => console.error(error),
    });
  }
}

@Component({
  selector: 'app-delete-dialog-content',
  template: `
    <div
      class="fixed inset-0 flex items-center justify-center bg-black bg-opacity-50 z-50"
    >
      <div class="max-w-lg w-full mx-auto bg-white p-8 rounded-md shadow-lg">
        <p class="text-center mb-6 text-lg font-bold">
          Are you sure you want to delete this product? This cannot be undone!
        </p>
        <div class="text-center">
          <button mat-button (click)="dialogRef.close(false)" class="py-2 px-4">
            Cancel
          </button>
          <button
            mat-button
            color="warn"
            (click)="dialogRef.close(true)"
            class="py-2 px-4"
          >
            Delete
          </button>
        </div>
      </div>
    </div>
  `,
  standalone: true,
  imports: [MatButton],
})
export class DeleteDialogContent {
  constructor(
    public dialogRef: MatDialogRef<DeleteDialogContent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}
}
