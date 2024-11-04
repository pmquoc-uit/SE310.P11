# Running the project

1. Chỉnh thông tin kết nối đến database trong tệp setting.json (Data Source=PMQ-DELLPCMS) bằng thông tin chính xác của Database Instance trên máy hiện tại:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=PMQ-DELLPCMS;Database=eCom;Trusted_Connection=True;Integrated Security=True;Encrypt=true;TrustServerCertificate=True;MultipleActiveResultSets=true"
  }
}
```

2. Chạy lệnh sau để restore project:
```bash
# run this from the API folder
cd eCom
dotnet watch run
```

3. Project chạy tại địa chỉ https://localhost:7149 cùng tài khoản mặc định là id: admin và pass: 111111

4. Dùng trang Admin quản lý tại địa chỉ https://localhost:7149/Admin để thực hiện thêm/xóa/sửa sản phẩm.