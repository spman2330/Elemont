Đây sẽ là src chính của dự án trong đó có các phần:
Dao là thư mục ghi về các class cũng như đối tượng
Dto sẽ là cách để dùng các câu lệnh sql để lấy về các đối tượng thỏa mãn
Gui sẽ là phần giao diện mình sẽ dùng để thiết kế ui tạm thời có 4 chức năng đi liền với 4 folder chính
trong đó thì beginForm là giao diện khởi đầu của cả chương trình.
Resource để lưu các file hoặc ảnh mà người dùng hoặc tài khoản hệ thống đăng lên như avt, icon map, hình pokemon (sẽ cân nhắc cho vào database sau) 
Static sẽ lưu các giá trị sẵn có của file như icon của app, tên tác giả hay là các thông tin của đa ngôn ngữ
.editorconfig dùng để config tab, space không cần quan tâm sẽ xử lí sau
program.cs là thứ sẽ mở beginForm (sẽ xem xét kết nối database trong đây)
.env File để lưu các giá trị mặc định như port của database (tạm thời sẽ chỉ có .envexample (tạm thời rỗng) ai dùng sẽ copy nội dung file này vào file .env tạo ra)
.gitignore sẽ bỏ qua các file đặc biệt không up lên git nhằm bảo mật như mật khẩu tài khoản database, tài khoản root