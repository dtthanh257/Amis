/**
 * Hàm check định dạng email
 * Author: DTThanh (27/07/2023)
 */
export function isValidEmail(email) {
  // Biểu thức chính quy để kiểm tra định dạng email
  const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  return emailPattern.test(email);
}
/**
 * Hàm check định dạng số điện thoại
 * Author: DTThanh (27/07/2023)
 */
export function isValidPhoneNumber(phoneNumber) {
  // Biểu thức chính quy để kiểm tra định dạng số điện thoại
  const phonePattern = /^\d{10,}$/;
  return phonePattern.test(phoneNumber);
}
/**
 * Hàm check định dạng ID
 * Author: DTThanh(27/07/2023)
 */
export function isValidId(idNumber) {
  const idPattern = /^\d{10,12}$/;
  return idPattern.test(idNumber);
}
/**
 * Hàm check ngày có hợp lệ không
 * Author:DTThanh (27/07/2023)
 */
export function isValidDate(date) {
  const day = new Date(date);
  const today = new Date();
  return day < today;
}
