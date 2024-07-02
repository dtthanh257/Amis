/**
 * Hàm xử lí lỗi từ phía API
 * Author: DTThanh (06/08/2023)
 */
import TheContainer from '@/components/layout/TheContainer.vue';
export function handleApiError(res) {

    const response = res.response;
    const statusCode = response.status;
    let msg = response.data.devMsg;
    switch (statusCode) {
        case 500:
            TheContainer.errors = "Dữ liệu trả về không hợp lệ";
            TheContainer.dialogName = true;
            break;
        case 400:
            TheContainer.errors = "Dữ liệu nhập không hợp lệ";
            TheContainer.dialogName = true;
            break;
            // Các trường hợp xử lý lỗi khác
        default:
            break;
    }
}