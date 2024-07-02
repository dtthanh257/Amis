/**
 * Định dạng ngày /tháng/nắm
 * Author:DTThanh(01/08/2023)
 */
export function formatDate(date) {
  try {
    if (!date) {
      return "";
    }
    const year = date.substr(0, 4);
    const month = date.substr(5, 2);
    const day = date.substr(8, 2);
    const formattedDate = `${day}/${month}/${year}`;
    return formattedDate;
  } catch (error) {
    console.log(error);
    return "";
  }
}

/**
 * Định dạng ngày /tháng/nắm
 * Author:DTThanh(01/08/2023)
 */
export function formatDate1(date) {
  try {
    if (!date) {
      return "";
    }
    const year = date.substr(0, 4);
    const month = date.substr(5, 2);
    const day = date.substr(8, 2);
    const formattedDate = `${year}-${month}-${day}`;
    return formattedDate;
  } catch (error) {
    console.log(error);
    return "";
  }
}
