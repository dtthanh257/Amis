import axios from "axios";

class EmployeeService {
    /**
     *
     * Gọi api đổ dữ liệu vào bảng
     * Author: DTThanh (31/07/2023)
     */
    async getEmployee() {
            return await axios({
                method: "get",
                url: "https://cukcuk.manhnv.net/api/v1/Employees",
            });
        }
        /**
         *
         * Gọi api lấy mã nhân viên mới
         * Author: DTThanh (31/07/2023)
         */
    async getEmployeeCode() {
            return await axios({
                method: "get",
                url: "https://cukcuk.manhnv.net/api/v1/Employees/NewEmployeeCode",
            });
        }
        /**
         *Gọi Api thêm mới 1 bản ghi
         * Author: DTThanh (31/07/2023)
         */
    async addEmployee(data) {
            return await axios({
                method: "post",
                url: "https://cukcuk.manhnv.net/api/v1/Employees",
                headers: {
                    accepts: "*/*",
                    "Content-Type": "application/json-patch+json",
                },
                data: data,
            });
        }
        /**
         * Api sửa nhân viên
         * Author: DTThanh (01/08/2023)
         */
    async updateEmployee(id, data) {
            return await axios({
                method: "put",
                url: "https://cukcuk.manhnv.net/api/v1/Employees/" + id,
                headers: {
                    accepts: "*/*",
                    "Content-Type": "application/json-patch+json",
                },
                data: data,
            });
        }
        /**
         *
         * Gọi api lấy thông tin của 1 nhân viên
         * Author: DTThanh (01/08/2023)
         */
    async getEmployeeInfo(id) {
            return await axios({
                method: "get",
                url: "https://cukcuk.manhnv.net/api/v1/Employees/" + id,
                headers: {
                    accepts: "*/*",
                    "Content-Type": "application/json-patch+json",
                },
            });
        }
        /**
   * 
   *Gọi Api xóa nhân viên khỏi bảng
   Author: DTThanh (01/08/2023)
 */
    async deleteEmployee(id) {
            return await axios({
                method: "delete",
                url: "https://cukcuk.manhnv.net/api/v1/Employees/" + id,
            });
        }
        /**
         * Gọi Api tìm kiếm nv
         * Author: DTThanh (07/08/2023)
         */
    async filterEmployee(key) {
        return await axios({
            method: "get",
            url: "https://cukcuk.manhnv.net/api/v1/Employees/filter?employeeFilter=" +
                key,
            headers: {
                accepts: "*/*",
                "Content-Type": "application/json-patch+json",
            },
        });
    }
}

export default new EmployeeService();