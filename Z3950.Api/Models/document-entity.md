#Trường dữ liệu có độ dài biến động được sắp xếp thành khối trường theo ký tự đầu tiên của nhãn trường. Ký tự này, ngoại trừ một vài ngoại lệ, xác định chức năng của dữ liệu bên trong biểu ghi. Kiểu thông tin trong trường được xác định bằng các những phần còn lại của nhãn trường.
 0XX - Thông tin kiểm soát, định danh, chỉ số phân loại,v.v.
 1XX - Tiêu đề chính
 2XX - Nhan đề và thông tin liên quan đến nhan đề (nhan đề, lần xuất bản, thông tin về in ấn)
 3XX - Mô tả vật lý, v.v.
 4XX - Thông báo về tùng thư
 5XX - Chú giải
 6XX - Các trường về truy cập chủ đề
 7XX - Tiêu đề bổ sung, không phải chủ đề hoặc tùng thư; trường liên kết
 8XX - Tiêu đề tùng thư bổ sung, sưu tập, v.v.
 9XX - Dành cho ứng dụng cục bộ.

#Bên trong các khối trường 1XX, 4XX, 6XX, 7XX và 8XX, có dự phòng một số cặp định danh nội dung. Những nội dung sau, ngoại trừ một vài ngoại lệ, được dành cho hai ký tự cuối của nhãn trường:
 X00     Tên cá nhân
 X10     Tên tổ chức
 X11     Tên hội nghị
 X30     Nhan đề đồng nhất
 X40     Nhan đề tùng thư
 X50     Thuật ngữ chủ đề
 X51     Tên địa lý

#Bên trong các trường dữ liệu có độ dài biến động, hai loại định danh nội dung sau được sử dụng:
 - Vị trí chỉ thị - Hai vị trí ký tự đầu tiên trong trường dữ liệu có độ dài biến động chứa thông tin để diễn giải hoặc bổ sung cho dữ liệu bên trong trường. Giá trị của chỉ thị được diễn giải một cách độc lập, nghĩa là ý nghĩa của của từng giá trị của hai chỉ thị sẽ không liên quan với nhau. Giá trị của chỉ thị có thể được nhập ở dạng chữ cái hoặc số. Một khoảng trống (mã ASCII SPACE), thể hiện trong tài liệu này bằng dấu thăng (#), được sử dụng cho vị trí chỉ thị không xác định. Trong vị trí chỉ thị nhất định, một khoảng trống có thể thông báo ý nghĩa hoặc có nghĩa là "không có thông tin".
 - Mã trường con - Hai ký tự để phân biệt những yếu tố dữ liệu bên trong một trường khi chúng đòi hỏi được xử lý riêng biệt. Một mã trường con gồm một ký tự phân cách trường (mã ASCII 1F hex), được ký hiệu trong tài liệu này bằng ký tự $, tiếp sau là một định danh phần tử dữ liệu. Định danh phần tử dữ liệu có thể là một ký tự chữ cái dạng chữ thường hoặc một ký tự dạng số. Mã trường con được xác định độc lập cho từng trường, tuy nhiên những ý nghĩa tương tự sẽ được duy trì bất kỳ lúc nào có thể (thí dụ trong các trường 100, 400 và 600 Tên cá nhân). Mã trường con được quy định với mục đích để xác định, mà không phải để sắp xếp. Thứ tự trường con thường được xác định bằng tiêu chuẩn cho nội dung dữ liệu, thí dụ quy tắc biên mục.