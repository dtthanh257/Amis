<template>
  <div class="table-footer d-flex-row">
    <div class="d-flex-row flex-1" :totalRecord="totalRecord">
      {{ " Tổng số: " + totalRecords + " bản ghi" }}
    </div>
    <div class="combo-page">
      <select name="" id="">
        <option value="0 ">10 bản ghi trên trang</option>
        <option value="1 ">20 bản ghi trên trang</option>
        <option value="2 ">30 bản ghi trên trang</option>
        <option value="3 ">40 bản ghi trên trang</option>
        <option value="4 ">50 bản ghi trên trang</option>
      </select>
    </div>
    <div class="table-page d-flex-row-center">
      <button class="table-page-pre icon icon-pre"></button>
      <button class="btn-footer-active">1</button>
      <button>2</button>
      <button>3</button>
      <button class="table-page-next icon icon-next"></button>
    </div>
  </div>
</template>
<script>
export default {
  name: "EmployeePagination",
  props: ["totalRecords"],
};
</script>
