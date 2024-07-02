<template>
  <div class="fix-menu">
    <div class="fix-option text-align-left d-flex align-item-center">Nhân bản</div>
    <div
      class="fix-option text-align-left d-flex align-item-center"
      :actionDialogText="actionDialogText"
      @click="this.showActionDialogs()"
    >
      Xóa
    </div>
    <div class="fix-option text-align-left d-flex align-item-center">Ngừng sử dụng</div>
  </div>
  <ActionDialog
    v-if="showActionDialog"
    :actionDialogText="this.actionDialogText"
    @cancelDialog="closeActionDialog()"
    @deleteEmployee="deleteEmployees()"
  />
  <ToastMsg :toastText="'Nhân viên đã được xoá'" v-if="showToastMessage" />
</template>
<script>
import EmployeeService from "@/services/employeeService";
import ToastMsg from "./ToastMsg.vue";
import ActionDialog from "@/components/layout/ActionDialog.vue";
import { handleApiError } from "@/helper/handleApiError";
export default {
  props: ["idEmployee"],
  name: "ContextMenu",
  components: { ActionDialog, ToastMsg },

  data() {
    return {
      showActionDialog: false,
      actionDialogText: "",
      showToastMessage: false,
    };
  },
  methods: {
    /**
     * Hàm xóa nhân viên
     * Author: DTThanh (01/08/2023)
     */
    deleteEmployees() {
      try {
        EmployeeService.deleteEmployee(this.idEmployee).then(() => {
          this.$emit("employeeDeleted");
        });
      } catch (res) {
        handleApiError(res);
      }
    },
    /**
     * Lây ra id của nhân viên bị xóa
     * Author: DTThanh(01/08/2023)
     */
    getEmployeeCode() {
      try {
        EmployeeService.getEmployeeInfo(this.idEmployee)
          .then((res) => {
            var data = JSON.parse(JSON.stringify(res));
            var employeeCode = data.data.EmployeeCode;
            this.actionDialogText = `Bạn có thực sự muốn xóa nhân viên ${employeeCode} không.`;
            return employeeCode;
          })
          .catch((res) => handleApiError(res));
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Hiện dialog khi ấn Xóa
     * Author: DTTHanh(01/08/2023)
     */
    showActionDialogs() {
      try {
        this.getEmployeeCode();
        this.showActionDialog = true;
        console.log(this.actionDialogText);
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * hàm đóng dialog khi bấm hủy
     * Author: DTTHanh(01/08/2023)
     */
    closeActionDialog() {
      try {
        this.showActionDialog = false;
      } catch (error) {
        console.log(error);
      }
    },
  },
};
</script>
