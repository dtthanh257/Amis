<template>
  <div id="toastMsg" class="toast-msg align-item-center d-flex-row">
    <div class="toast-msg-dscr d-flex-row align-item-center">
      <div class="d-flex-row gap-10 h-56 align-item-center">
        <div class="icon icon-toast-success"></div>
        <div class="toast-dscr"><b>Thành công!</b></div>
        <div class="toast-text">{{ toastText }}</div>
      </div>
    </div>
    <div class="icon icon-toast-close"></div>
  </div>
</template>
<script>
export default {
  name: "ToastMsg",
  props: ["toastText"],
};
</script>
<style></style>
