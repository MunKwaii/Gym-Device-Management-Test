using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTB
{
    public static class SqlErrorHandler
    {
        public static string Translate(SqlException ex)
        {
            foreach (SqlError error in ex.Errors)
            {

                if (error.Message.Contains("Không thể chuyển trực tiếp từ Bẩn sang Sạch"))
                    return "Không thể chuyển trực tiếp từ Bẩn sang Sạch. Hãy qua trạng thái Đang vệ sinh trước.";

                if (error.Message.Contains("Thiết bị không ở trạng thái Đang sử dụng"))
                    return "Thiết bị không ở trạng thái đang sử dụng nên không thể cập nhật vệ sinh.";

                switch (error.Number)
                {
                    case 229:  
                        return "Bạn không có quyền thực hiện thao tác này.";
                    case 2627:  
                        return "Dữ liệu đã tồn tại, vui lòng nhập giá trị khác.";
                    case 547:   
                        return "Không thể xóa/cập nhật vì dữ liệu đang được tham chiếu.";
                    case 515:   
                        return "Một số trường bắt buộc chưa được nhập.";
                    default:
                        return error.Message; 
                }
            }
            return "Có lỗi SQL không xác định.";
        }
    }
}
