<template>
  <div id="dialogName" class="dialog-modal">
    <div class="dialog">
      <div class="dialog-content d-flex-row mb-24">
        <div class="icon-dialog-warning icon"></div>
        <div class="dialog-discr">{{ this.actionDialogText }}</div>
      </div>
      <!-- <div  class="dialog-bottom d-flex-row-sbw gap-8">
        <button class="btn btn-sec" @click="closeActionDialog()">Hủy</button>
        <button class="btn btn-pri" @click="deleteEmployees()">Có</button>
      </div> -->
      <div class="dialog-bottom d-flex-row-sbw gap-8">
        <button class="btn btn-sec" @click="closeActionDialog()">Không</button>
        <button class="btn btn-pri" @click="deleteEmployees()">Có</button>
      </div>
    </div>
  </div>
  <ToastMsg v-if="successDelete" :toastText="toastText" />
  <TheLoadingModal v-if="loadingModal" />
</template>
<script>
import ToastMsg from "./ToastMsg.vue";
import TheLoadingModal from "./TheLoadingModal.vue";
export default {
  name: "ActionDialog",
  props: {
    actionDialogText: String,
  },
  emits: "deleteEmployee",
  components: { ToastMsg, TheLoadingModal, TheLoadingModal },
  data() {
    return {
      successDelete: false,
      toastText: "",
      loadingModal: false,
    };
  },
  methods: {
    /**
     * Hàm show loading modal
     * Author:DTThanh (07/08/2023)
     */
    showLoadingModal() {
      this.loadingModal = true;
    },
    /**
     * Hàm close Loading Modal
     * Author: DTThanh (07/08/2023)
     */
    closeLoadingModal() {
      this.loadingModal = false;
    },
    /**
     * Gọi hàm đóng dialog trong ContextMenu
     * Author: DTThanh(01/08/2023)
     */
    closeActionDialog() {
      this.$emit("cancelDialog");
    },
    /**
     * Gọi hàm xóa trong ContextMenu
     * Author: DTThanh(01/08/2023)
     */
    deleteEmployees() {
      this.showLoadingModal();
      this.$emit("deleteEmployee");
      this.toastText = "Chỉnh sửa thông tin thành công";
      this.successAddToast = true;
      setTimeout(() => {
        this.successAddToast = false;
      }, 3000);
      this.closeLoadingModal();
    },
  },
};
</script>
<style></style>
