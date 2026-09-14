# 🎱 POOL TOURNAMENT MANAGEMENT

## Hệ thống quản lý giải đấu bida

Hệ thống quản lý giải đấu bida được xây dựng nhằm hỗ trợ việc tổ chức, quản lý và theo dõi các giải đấu Pool một cách thuận tiện và hiệu quả.

Hệ thống hỗ trợ quản lý người chơi, giải đấu, bàn bida, lịch thi đấu, bốc thăm, bảng đấu, kết quả trận đấu và thống kê. Ứng dụng được phát triển dưới dạng Desktop App sử dụng C# WinForms và kết nối cơ sở dữ liệu MySQL.

---

## 📌 Giới thiệu

Trong việc tổ chức một giải đấu bida, việc quản lý thông tin người chơi, chia bảng, sắp xếp lịch thi đấu và cập nhật kết quả nếu thực hiện thủ công sẽ mất nhiều thời gian và dễ xảy ra sai sót.

Vì vậy, hệ thống **Pool Tournament Management** được xây dựng nhằm:

- Quản lý thông tin người chơi.
- Quản lý các giải đấu.
- Quản lý bàn bida.
- Quản lý lịch thi đấu.
- Hỗ trợ bốc thăm và chia bảng.
- Quản lý bảng đấu và nhánh đấu.
- Cập nhật kết quả các trận đấu.
- Theo dõi tiến trình giải đấu.
- Thống kê và tổng hợp thông tin giải đấu.
- Quản lý tài khoản và phân quyền người dùng.

---

# 🎯 Mục tiêu của hệ thống

Hệ thống hướng đến việc số hóa các nghiệp vụ trong quá trình tổ chức giải đấu bida.

### Các mục tiêu chính:

- Giảm thời gian quản lý giải đấu.
- Hạn chế sai sót khi nhập và xử lý dữ liệu.
- Hỗ trợ tổ chức giải đấu khoa học.
- Dễ dàng theo dõi lịch thi đấu và kết quả.
- Tập trung toàn bộ dữ liệu vào một hệ thống.
- Hỗ trợ người quản lý theo dõi tình trạng giải đấu.
- Tạo giao diện trực quan, dễ sử dụng.

---

# ⚙️ Chức năng chính

## 1. 🔐 Đăng nhập

- Đăng nhập bằng tài khoản.
- Kiểm tra tên đăng nhập và mật khẩu.
- Phân quyền người dùng.
- Đăng xuất khỏi hệ thống.

---

## 2. 👤 Quản lý người chơi

Cho phép quản lý thông tin các cơ thủ tham gia giải đấu.

Các chức năng:

- Thêm người chơi.
- Cập nhật thông tin người chơi.
- Xóa người chơi.
- Tìm kiếm người chơi.
- Xem danh sách người chơi.
- Quản lý trạng thái người chơi.

Thông tin người chơi có thể bao gồm:

- Mã người chơi.
- Họ tên.
- Số điện thoại.
- Email.
- Ngày sinh.
- Thông tin liên quan khác.

---

## 3. 🏆 Quản lý giải đấu

Cho phép quản lý toàn bộ thông tin của các giải đấu.

Các chức năng:

- Tạo giải đấu mới.
- Cập nhật thông tin giải đấu.
- Xóa giải đấu.
- Xem danh sách giải đấu.
- Quản lý trạng thái giải đấu.
- Quản lý thời gian tổ chức.
- Quản lý số lượng người chơi.
- Theo dõi tiến độ giải đấu.

Thông tin giải đấu:

- Mã giải đấu.
- Tên giải đấu.
- Thể thức thi đấu.
- Ngày bắt đầu.
- Ngày kết thúc.
- Số lượng người chơi.
- Trạng thái giải đấu.

---

## 4. 🎱 Quản lý bàn bida

Quản lý các bàn bida được sử dụng trong quá trình tổ chức giải.

Các chức năng:

- Thêm bàn bida.
- Cập nhật thông tin bàn.
- Xóa bàn.
- Xem danh sách bàn.
- Theo dõi trạng thái bàn.

Trạng thái bàn có thể gồm:

- Trống.
- Đang sử dụng.
- Đang bảo trì.

---

## 5. 🎲 Bốc thăm và chia bảng

Hỗ trợ tổ chức người chơi vào các bảng đấu.

Các chức năng:

- Chọn giải đấu.
- Lựa chọn danh sách người chơi.
- Bốc thăm người chơi.
- Chia người chơi vào các bảng.
- Xem kết quả bốc thăm.
- Quản lý danh sách bảng đấu.

---

## 6. 🏅 Quản lý bảng đấu

Theo dõi các trận đấu trong từng bảng.

Hệ thống hỗ trợ:

- Xem danh sách bảng.
- Xem người chơi trong bảng.
- Xem các trận đấu.
- Cập nhật kết quả.
- Theo dõi điểm số.
- Theo dõi thứ hạng.
- Xác định người chơi đi tiếp.

---

## 7. 🥇 Quản lý nhánh đấu

Quản lý các vòng đấu loại trực tiếp.

Ví dụ:

```text
Vòng 1
   ↓
Tứ kết
   ↓
Bán kết
   ↓
Chung kết
   ↓
🏆 Nhà vô địch
