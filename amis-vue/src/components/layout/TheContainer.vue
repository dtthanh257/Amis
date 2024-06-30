<template>
  <div class="container">
    <div class="container-employ">
      <h3 class="container-employ-title">Nhân viên</h3>
     
      <MisaButton :buttonClass="`btn btn-pri`"
      :buttonText="'Thêm mới nhân viên'"
      @click="showEmployeeForm()"
      />
    </div>
    <div class="container-content">
      <div class="container-content-action">
        <div
          class="checked-emp d-flex-row gap-16 align-item-center"
          style="flex: 1"
        >
          <div class="checked-row" v-if="this.checkedRow >= 1">
            Đã chọn: {{ this.checkedRow }}
          </div>
          <div
            class="check-remove"
            style="color: red; cursor: pointer"
            v-if="this.checkedRow >= 1"
            @click="deselectAll"
          >
            Bỏ chọn
          </div>
          <button
            class="btn btn-sec"
            style="height: 36px; width: fit-content"
            v-if="this.checkedRow >= 1"
            @click="deleteSelectedEmployees()"
          >
            Xóa tất cả
          </button>
        </div>
        <div class="textfield default">
          <div class="textfield-with-acion">
            <input
              type="text"
              name="input"
              placeholder="Tìm theo mã, tên nhân viên"
              v-model="filterText"
              @keyup.enter="getFilterEmployee(filterText)"
            />
            <span @click="getFilterEmployee(filterText)"
              ><i class="fa-solid fa-magnifying-glass"></i
            ></span>
          </div>
        </div>
        <div class="icon icon-reload" @click="reloadData()"></div>
      </div>
      <div class="container-content-table m-table">
        <table>
          <thead>
            <tr class="table-head">
              <th class="text-align-center"><input type="checkbox" /></th>
              <th class="text-align-left">MÃ NHÂN VIÊN</th>
              <th class="text-align-left mw-200" style="max-width:340px;overflow: hidden;">TÊN NHÂN VIÊN</th>
              <th class="text-align-left" style="max-width:80px;">GIỚI TÍNH</th>
              <th class="text-align-center">NGÀY SINH</th>
              <th class="text-align-left" id="idCol">
                <div class="id-text">
                  Số CMND
                  <div class="id-tooltip">Số chứng minh nhân dân</div>
                </div>
              </th>
              <th class="text-align-left">CHỨC DANH</th>
              <th class="text-align-left">TÊN ĐƠN VỊ</th>
              <th class="text-align-left">TÊN NGÂN HÀNG</th>
              <th class="text-align-left">CHI NHÁNH NGÂN HÀNG</th>
              <th class="text-align-right">CHỨC NĂNG</th>
            </tr>
          </thead>

          <tbody id="employeeData">
            <tr
              v-for="(employee, index) in this.tableData"
              :key="index"
              :class="{ 'selected-row': employee.isChecked }"
            >
              <td class="text-align-center d-flex-row-center" style="position: relative">
                <input
                  type="checkbox"
                  @click="toggleCheckbox(employee)"
                  v-model="employee.isChecked"
                />
              </td>
              <td class="text-align-left">{{ employee.EmployeeCode }}</td>
              <td class="text-align-left mw-200" style="max-width:340px;overflow: hidden;">{{ employee.FullName }}</td>
              <td class="text-align-left">{{ employee.GenderName }}</td>
              <td class="text-align-center">
                {{ formatDateOB(employee.DateOfBirth) }}
              </td>
              <td class="text-align-left">{{ employee.IdentityNumber }}</td>
              <td class="text-align-left">{{ employee.PositionName }}</td>
              <td class="text-align-left">{{ employee.DepartmentName }}</td>
              <td class="text-align-left">{{ "ACB" }}</td>
              <td class="text-align-left">{{ "Hà Nội" }}</td>
              <td class="text-align-right">
                <div class="d-flex-row-center gap-8" style="position: relative">
                  <button
                    class="btn btn-fix btn-link"
                    @click="
                      showUpdateEmployeeForm(
                        employee.EmployeeId,
                        employee.EmployeeCode,
                        employee.FullName,
                        employee.Gender,
                        employee.IdentityNumber,
                        employee.PositionName,
                        employee.DepartmentName,
                        employee.DateOfBirth,
                        employee.Address,
                        employee.PhoneNumber,
                        employee.Email,
                        employee.IdentityPlace,
                        employee.IdentityDate,
                      )
                    "
                  >
                    Sửa
                  </button>
                  <button
                    class="btn-link btn-drop-down-fix show-fix-menu"
                    @click="showFixMenu(employee.EmployeeId)"
                  ></button>
                  <ContextMenu
                    :idEmployee="employee.EmployeeId"
                    v-if="employeeIdContextMenu == employee.EmployeeId"
                    @employeeDeleted="getEmployeesData"
                  ></ContextMenu>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
        <EmployeePagination :totalRecords="this.totalRecords" />
      </div>
    </div>
    <div class="employ-form" v-if="this.showForm">
      <div class="employ-form-container">
        <div class="form-header">
          <h1 class="form-title">Thông tin nhân viên</h1>
          <div class="employ-check">
            <div class="is-check"><input type="checkbox" />Là khách hàng</div>
            <div class="is-check"><input type="checkbox" />Là nhà cung cấp</div>
          </div>
          <div class="form-header-action">
            <button class="form-help"> <span>Trợ giúp</span></button>
            <button
              class="form-close"
              id="formClose"
              @click="closeForm()"
            ><span>Đóng form</span></button>
          </div>
        </div>
        <div class="d-flex-row gap-28">
          <div class="employ-info w1-2">
            <div class="d-flex-row gap-8">
              <div
                class="textfield w2-5"
                :class="{
                  'textfield-error textfield-code-error': textfieldCode,
                  'textfield-error textfield-have-code-warning':
                    textfieldHaveCode,
                }"
                id="codeTextfield"
              >
                <label for="myInput">Mã nhân viên <span class="require">*</span></label>
                <input
                  id="txtEpCode"
                  v-model="this.formUpdate.employeeCode"
                  type="text"
                  name="input"
                  placeholder=""
                  ref="inputElement"
                />
              </div>
              <div
                class="textfield w3-5"
                :class="{
                  'textfield-error textfield-name-error': textfieldName,
                }"
                id="nameTextfield"
              >
                <label>Tên <span class="require">*</span></label>
                <input
                  id="txtEmployeeName"
                  v-model="this.formUpdate.fullName"
                  type="text"
                  name="input"
                  placeholder=""
                />
              </div>
            </div>

            <div
              class="textfield"
              :class="{
                'textfield-error textfield-department-error':
                  textfieldDepartment,
              }"
              id="departmentTextfield"
            >
              <label>Đơn vị <span class="require">*</span></label>
              <input
                id="txtEmployeeDepartment"
                v-model="this.formUpdate.departmentName"
                @change="inputOnchange()"
                type="text"
                name="input"
                placeholder=""
              />
            </div>
            <div class="textfield">
              <label>Chức danh</label>
              <input
                id="txtEmployeePosition"
                type="text"
                v-model="this.formUpdate.positionName"
                name="input"
                placeholder=""
              />
            </div>
          </div>
          <div class="employ-info w1-2">
            <div class="d-flex-row gap-16">
              <div class="textfield">
                <label>Ngày sinh</label>
                <input
                  id="employeeDateOfBirth"
                  v-model="this.formUpdate.dateOfBirth"
                  type="date"
                  name="input"
                  placeholder="DD/MM/YYYY"
                />
              </div>
              <div class="textfield">
                <label>Giới tính</label>
                <div class="textfield-flex" style="accent-color: var(--color-accent);">
                  <div class="gender">
                    <input
                    style="cursor: pointer"
                      type="radio"
                      name="gender"
                      value="0"
                      placeholder=""
                      checked
                    />Nam
                  </div>
                  <div class="gender">
                    <input
                      style="cursor: pointer"
                      type="radio"
                      name="gender"
                      value="1"
                      placeholder=""
                    />Nữ
                  </div>
                  <div class="gender">
                    <input
                    style="cursor: pointer"
                      type="radio"
                      name="gender"
                      value="2"
                      placeholder=""
                    />Khác
                  </div>
                </div>
              </div>
            </div>
            <div class="d-flex-row">
              <div class="textfield-flex gap-8">
                <div class="textfield w3-5 tooltip-place-id">
                  <label>Số CMND</label>
                  <input
                    id="employeeIdentity"
                    type="number"
                    name="input"
                    v-model="this.formUpdate.identityNumber"
                    placeholder=""
                  />
                  <div class="tooltip-id">
                    Nhập số Chứng minh nhân dân của bạn
                  </div>
                </div>
                <div class="textfield w2-5">
                  <label>Ngày cấp</label>
                  <input
                    id="employeeIdentityDate"
                    v-model="this.formUpdate.identityDate"
                    type="date"
                    name="input"
                    placeholder="DD/MM/YYYY"
                  />
                </div>
              </div>
            </div>
            <div class="textfield">
              <label>Nơi cấp</label>
              <input
                id="employeeIdentityPlace"
                type="text"
                v-model="this.formUpdate.indentityPlace"
                name="input"
                placeholder=""
              />
            </div>
          </div>
        </div>
        <div class="d-flex-column">
          <div class="textfield w1-1">
            <label>Địa chỉ</label>
            <input
              id="employeeAddress"
              type="text"
              name="input"
              v-model="this.formUpdate.address"
              placeholder=""
            />
          </div>
          <div class="d-flex-row gap-8 w4-5">
            <div class="textfield w1-1 tooltip-place-phone">
              <label>ĐT di động</label>
              <input
                id="employeePhone"
                type="number"
                name="input"
                v-model="this.formUpdate.phoneNumber"
                placeholder=""
              />
              <div class="tooltip-phone">
                Nhập số điện thoại di động của bạn
              </div>
            </div>
            <div class="tooltip-place-phone-main textfield w1-1">
              <label>ĐT cố định</label>
              <input type="number" name="input" placeholder="" />
              <div class="tooltip-phone-main">
                Nhập số điện thoại cố định của bạn
              </div>
            </div>
            <div class="textfield w1-1">
              <label>Email</label>
              <input
                id="employeeEmail"
                v-model="this.formUpdate.email"
                type="text"
                name="input"
                placeholder=""
              />
            </div>
          </div>
          <div class="d-flex-row gap-8 w4-5">
            <div class="textfield w1-1">
              <label>Tài khoản ngân hàng</label>
              <input type="text" name="input" placeholder="" />
            </div>
            <div class="textfield w1-1">
              <label>Tên ngân hàng</label>
              <input type="text" name="input" placeholder="" />
            </div>
            <div class="textfield w1-1">
              <label>Chi nhánh</label>
              <input type="text" name="input" placeholder="" />
            </div>
          </div>
        </div>
        <div class="form-footer">
          <div class="d-flex-row gap-8">
            <div class="form-footer-action btn-flex-1">
              <button class="btn btn-sec" @click="closeForm()">Hủy</button>
            </div>
            <div class="form-footer-action gap-12">
              <button
                class="btn btn-sec"
                v-if="formMode === $MISAEnum.FORM_MODE.ADD"
                @click="addAndCloseForm()"
              >
                Cất
              </button>
              <button
                class="btn btn-sec"
                v-if="formMode === $MISAEnum.FORM_MODE.UPDATE"
                @click="updateEmployees()"
              >
                Cất
              </button>
              <button
                class="btn btn-pri"
                :dialogText="dialogText"
                :dialogTitle="dialogTitle"
                :dialog="dialog"
                @click="validateText()"
              >
                Cất và thêm
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
    <ActionDialog v-if="closeFormDialog"></ActionDialog>
    <TheDialog
      v-if="dialogName"
      @close-dialog="closeDialog()"
      :dialogTitle="'Lưu ý'"
      :errors="errors"
      :dialogText="'Tên nhân viên không được phép để trống.'"
    />

    <TheDialog
      v-if="dialogHaveCode"
      @close-dialog="closeDialog()"
      :dialogTitle="'Cảnh báo'"
      :errors="errors"
      :dialogText="'Mã nhân viên đã tồn tại trong hệ thống'"
      :dialogHaveCode="dialogHaveCode"
    />
    <TheDialog
      v-if="dialogFailInput"
      @close-dialog="closeDialog()"
      :dialogTitle="'Cảnh báo'"
      :errors="errors"
      :dialogText="'Email sai định dạng'"
      :dialogHaveCode="dialogFailInput"
    />
    <ToastMsg v-if="successAddToast" :toastText="toastText" />
    <ToastMsg v-if="failAddToast" :toastText="toastText" />
    <TheLoadingModal v-if="loadingModal" />
  </div>
</template>
<script>
import EmployeeService from "@/services/employeeService.js";
import TheDialog from "@/components/layout/TheDialog.vue";
import ContextMenu from "@/components/layout/ContextMenu.vue";
import ToastMsg from "@/components/layout/ToastMsg.vue";
import ActionDialog from "@/components/layout/ActionDialog.vue";
import { formatDate, formatDate1 } from "@/helper/format";
import EmployeePagination from "./EmployeePagination.vue";
import MisaButton from "../base/MisaButton.vue";
import MsCombobox from "ms-combobox"
// import mscombobox from 'ms-combobox';
import {
  isValidDate,
  isValidEmail,
} from "@/helper/isValidCheck";
import { handleApiError } from "@/helper/handleApiError.js";
import MISAEnum from "@/helper/enum.js";
import TheLoadingModal from "./TheLoadingModal.vue";

export default {
  name: "TheContainer",
  components: {
    MisaButton,
    ActionDialog,
    TheDialog,
    ContextMenu,
    ToastMsg,
    EmployeePagination,
    TheLoadingModal,
  },
  data() {
    return {
      buttonClass:"",
      buttonText:"",
      tableData: [], // Mảng lưu trữ dữ liệu nhân viên
      totalRecords: 0,
      showForm: false,
      textfieldCode: "",
      textfieldHaveCode: false,
      textfieldName: "",
      textfieldDepartment: "",
      dialogDepartment: false,
      dialogHaveCode: false,
      dialogName: false,
      dialogCode: false,
      dialogFailInput: false,
      employeeDepartment: "",
      employeeName: "",
      dialogText: "",
      toastText: "",
      dialogTitle: "",
      isMenuOpen: false,
      fixMenu: false,
      formUpdate: {
        employeeId: "",
        employeeCode: "",
        fullName: "",
        gender: "",
        dateOfBirth: "",
        identityNumber: "",
        positionName: "",
        departmentName: "",
        address: "",
        email: "",
        indentityPlace: "",
        phoneNumber: "",
        identityDate: "",
      },
      showContextMenu: false,
      employeeIdContextMenu: "",
      successAddToast: false,
      failAddToast: "",
      errors: "",
      formMode: null,
      checkedRow: 0,
      filterText: "",
      closeFormDialog: false,
    };
  },

  async mounted() {
    await this.getEmployeesData(); // Gọi hàm để lấy dữ liệu từ API khi component được mount
  },
  methods: {
    /**
     * Hàm tìm kiếm nhân viên
     * Author: DTThanh (07/08/2023)
     */
    async getFilterEmployee(key) {
      const response = await EmployeeService.filterEmployee(key);
      this.tableData = response.data.Data; // Lưu dữ liệu từ API vào biến tableData
      if (response.data.Data) {
        this.totalRecords = response.data.Data.length;
      } else this.totalRecords = 0;
      console.log(response.data.Data);
    },
    /**
     *
     * Hàm check ô input đã check hay chưa
     * Author: DTThanh (06/08/2023)
     */
    toggleCheckbox(employee) {
      employee.isChecked = !employee.isChecked;
      this.countCheckedCheckboxes();
    },
    /**
     *
     * Hàm đếm số ô input checked
     * Author: DTThanh (06/08/2023)
     */
    countCheckedCheckboxes() {
      this.checkedRow = this.tableData.reduce(
        (count, employee) => count + (employee.isChecked ? 1 : 0),
        0,
      );
    },
    /**
     *
     * Hàm bỏ chọn tất cả các ô input checked
     * Author: DTThanh (06/08/2023)
     */
    deselectAll() {
      // Set the isChecked property of each employee object to false
      this.tableData.forEach((employee) => (employee.isChecked = false));
      this.checkedRow = 0; // Reset the checkedRow count
    },
    /**
     * Xóa các ô input được chọn
     * Author: DTThanh (07/08/2023)
     */
    deleteSelectedEmployees() {
      this.showLoadingModal();
      const employeesToDelete = this.tableData.filter(
        (employee) => employee.isChecked,
      );

      const deletePromises = employeesToDelete.map((employee) =>
        this.deleteEmployees(employee),
      );

      Promise.all(deletePromises)
        .then(() => {
          this.tableData.forEach((employee) => (employee.isChecked = false));
          this.checkedRow = 0;
          this.toastText = "Xóa nhân viên thành công";
          this.successAddToast = true;
          setTimeout(() => {
            this.successAddToast = false;
          }, 3000);
        })
        .catch((error) => {
          console.log(error);
        })
        .finally(() => {
      this.closeLoadingModal(); 
    });;
    },

    /**
     * Xóa 1 nhân viên
     * Author: DTThanh (07/08/2023)
     */
    deleteEmployees(employee) {
      try {
        console.log("aloalo");
        console.log(employee.EmployeeId);
        EmployeeService.deleteEmployee(employee.EmployeeId).then(() => {
          console.log(employee.EmployeeId);
          if (this.filterText != "") {
            this.getFilterEmployee(this.filterText);
          }
          this.getEmployeesData();
        });
      } catch (error) {
        handleApiError(error);
      }
    },
    /**
     * Hàm tải dữ liệu vào bảng
     * Author:DTThanh (31/07/2023)
     */
    async getEmployeesData() {
      try {

        const response = await EmployeeService.getEmployee();
        this.tableData = response.data; // Lưu dữ liệu từ API vào biến tableData
        this.totalRecords = response.data.length;
        this.checkedRow = 0;
        console.log(response);
     
      } catch (error) {
        console.error("Lỗi khi lấy dữ liệu từ API:", error);
      }
      
    },
    /**
     * Mở form thêm nhân viên
     * Author: DTThanh (31/07/2023)
     */
    showEmployeeForm() {
      var errors = [];
      this.formMode = MISAEnum.FORM_MODE.ADD;
      this.formUpdate.employeeId = "";
      this.formUpdate.employeeCode = "";
      this.formUpdate.fullName = "";
      this.formUpdate.gender = "";
      this.formUpdate.identityNumber = "";
      this.formUpdate.positionName = "";
      this.formUpdate.departmentName = "";
      this.formUpdate.dateOfBirth = "";
      this.formUpdate.address = "";
      this.formUpdate.phoneNumber = "";
      this.formUpdate.email = "";
      this.formUpdate.indentityPlace = "";
      this.formUpdate.identityDate = "";
      this.showForm = true;
      this.$nextTick(() => {
        this.$refs.inputElement.focus();
      });
      EmployeeService.getEmployeeCode().then((response) => {
        try {
          this.formUpdate.employeeCode = response.data; // Cập nhật giá trị mã nhân viên vào txtEpCode
        } catch (error) {
          const response = err.response;
          const statusCode = response.status;
          let msg = response.data?.devMsg;
          switch (statusCode) {
            case 500:
              errors.push("Dữ liệu trả về không hợp lệ");
              break;
            case 400:
              errors.push("Dữ liệu nhập không hợp lệ");
          }
          if (errors.length != 0) {
            this.errors = errors;
            this.dialogFailInput = true;
          }
        }
      });
    },
    /**
     * Đóng form thêm nhân viên
     * Author: DTThanh (31/07/2023)
     */
    closeForm() {
      try {
        this.formUpdate.fullName = "";
        this.formUpdate.departmentName = "";
        this.textfieldDepartment = false;
        this.textfieldName = false;
        this.textfieldCode = false;
        this.showForm = false;
      } catch (err) {
        console.log(err);
      }
    },
    /**
     * Hàm vailidate và thêm nhân viên
     * Author:DTThanh (01/08/2023)
     */
    validate() {
      var errors = [];
      if (
        this.formUpdate.employeeCode === "" ||
        this.formUpdate.fullName === "" ||
        this.formUpdate.departmentName === ""
      ) {
        if (this.formUpdate.employeeCode === "") {
          this.textfieldCode = true;
          this.toastText = `Thêm mới nhân viên thất bại`;
          errors.push("Mã nhân viên không được phép để trống.");

          this.successFailToast = true;

          setTimeout(() => {
            this.failToast = false;
            console.log("s");
          }, 3000);
        } else {
          this.textfieldCode = false;
        }
        if (this.formUpdate.fullName === "") {
          this.textfieldName = true;
          errors.push("Họ và tên không được phép để trống.");
          console.log(errors);
          this.toastText = `Thêm mới nhân viên thất bại`;
          this.successFailToast = true;
          setTimeout(() => {
            this.failToast = false;
            console.log("s");
          }, 3000);
        } else {
          this.textfieldName = false;
        }
        if (this.formUpdate.departmentName === "") {
          this.textfieldDepartment = true;
          this.toastText = `Thêm mới nhân viên thất bại`;
          errors.push("Tên đơn vị không được phép để trống.");
          console.log("ten don vi khong duoc de trong");
          this.successFailToast = true;
          setTimeout(() => {
            this.failToast = false;
            console.log("s");
          }, 3000);
        } else {
          this.textfieldDepartment = false;
        }
        this.errors = errors;
        this.dialogName = true;
        return;
      } else if (
        this.tableData != null &&
        this.tableData != undefined &&
        this.tableData.length != 0
      ) {
        this.textfieldCode = false;
        this.textfieldDepartment = false;
        this.textfieldName = false;
        let employeeWithCode = this.tableData.filter((data) => {
          try {
            return data.EmployeeCode == this.formUpdate.employeeCode.trim();
          } catch (error) {
            console.log(error);
          }
        });
        
      }
    },
    /**
     * Hàm vailidate và thêm nhân viên
     * Author:DTThanh (01/08/2023)
     */
    async validateText() {
      /* eslint-disable */
      var errors = [];
      this.validate();  
     
      if (
        this.formUpdate.employeeCode != "" &&
        this.formUpdate.fullName != "" &&
        this.formUpdate.departmentName != ""
      ) {
        this.textfieldCode = false;
        this.textfieldDepartment = false;
        this.textfieldName = false;
        const employeeData = {
          employeeCode: this.formUpdate.employeeCode,
          fullName: this.formUpdate.fullName,
          gender: 0,
          dateOfBirth: this.formUpdate.dateOfBirth,
          phoneNumber: this.formUpdate.phoneNumber,
          email: this.formUpdate.email,
          address: this.formUpdate.address,
          identityNumber: this.formUpdate.identityNumber,
          identityDate: this.formUpdate.identityDate,
          identityPlace: this.formUpdate.indentityPlace,
          departmentCode: this.formUpdate.positionName,
          departmentName: this.formUpdate.departmentName,
        };
        if (employeeData.email != "") {
          if (this.checkEmail(employeeData.email) == false) {
            console.log("email sai roi");
            errors.push("Email đã nhập sai định dạng.");
          }
        }
        if (employeeData.dateOfBirth != "") {
          if (this.checkDate(employeeData.dateOfBirth) == false) {
            console.log("ngay lon hon ngay hien tai");
            errors.push("Ngày sinh không được lớn hơn ngày hiện tại.");
          }
        }
        if (employeeData.identityDate != "") {
          if (this.checkDate(employeeData.identityDate) == false) {
            console.log("ngay cap lon hon ngay hien tai");
            errors.push("Ngày cấp không được lớn hơn ngày hiện tại.");
          }
        }
        if (errors.length != 0) {
          this.errors = errors;
          this.dialogFailInput = true;
          return;
        } else {
              
          var errores = [];
          var raw = JSON.stringify(employeeData);

          EmployeeService.addEmployee(raw)
            .then(() => {
              this.toastText = `Thêm mới thành công`;
              this.successAddToast = true;
              setTimeout(() => {
                this.successAddToast = false;
              }, 3000);
              this.getEmployeesData();
              this.showEmployeeForm();
            })
            .catch((err) => {
              const response = err.response;
              const statusCode = response.status;
              let msg = response.data?.devMsg;
              switch (statusCode) {
                case 500:
                  errores.push("Mã nhân viên đã tồn tại trong hệ thống.");
                  break;
                case 400:
                  errores.push(msg);
                  break;
              }
              if (errores.length != 0 ) {
                console.log(this.errors);
                this.errors = errores;
                this.dialogFailInput = true;
                return;

              }
            });
        }
      }
    },
    /**
     * Thêm và đóng form
     * Author: DTThanh (07/08/2023)
     */
    addAndCloseForm() {
      var errors = [];
      this.validate();
      if (
        this.formUpdate.employeeCode != "" &&
        this.formUpdate.fullName != "" &&
        this.formUpdate.departmentName != ""
      ) {
        this.textfieldCode = false;
        this.textfieldDepartment = false;
        this.textfieldName = false;
        const employeeData = {
          employeeCode: this.formUpdate.employeeCode,
          fullName: this.formUpdate.fullName,
          gender: 0,
          dateOfBirth: this.formUpdate.dateOfBirth,
          phoneNumber: this.formUpdate.phoneNumber,
          email: this.formUpdate.email,
          address: this.formUpdate.address,
          identityNumber: this.formUpdate.identityNumber,
          identityDate: this.formUpdate.identityDate,
          identityPlace: this.formUpdate.indentityPlace,
          departmentCode: this.formUpdate.positionName,
          departmentName: this.formUpdate.departmentName,
        };
        if (employeeData.email.trim() != "") {
          if (this.checkEmail(employeeData.email) == false) {
            console.log("email sai roi");
            errors.push("Email đã nhập sai định dạng.");
          }
        }
        if (employeeData.dateOfBirth != "") {
          if (this.checkDate(employeeData.dateOfBirth) == false) {
            console.log("ngay lon hon ngay hien tai");
            errors.push("Ngày sinh không được lớn hơn ngày hiện tại.");
          }
        }
        if (employeeData.identityDate != "") {
          if (this.checkDate(employeeData.identityDate) == false) {
            console.log("ngay cap lon hon ngay hien tai");
            errors.push("Ngày cấp không được lớn hơn ngày hiện tại.");
          }
        }
        if (errors.length != 0) {
          this.errors = errors;
          this.dialogFailInput = true;
          return;
        } else {
          console.log(this.errors);
          var raw = JSON.stringify(employeeData);

          EmployeeService.addEmployee(raw)
            .then(() => {
              this.toastText = `Thêm mới thành công`;
              this.successAddToast = true;
              setTimeout(() => {
                this.successAddToast = false;
              }, 3000);
              this.getEmployeesData();
              this.closeForm();
            })
            .catch((res) => {
              const response = res.response;
              const statusCode = response.status;
              let msg = response.data?.devMsg;
              switch (statusCode) {
                case 500:
                  errors.push( 'Mã nhân viên đã tồn tại trong hệ thống.');
                  break;
                case 400:
                  errors = [msg];
              }
              if (errors.length != 0) {
                this.errors = errors;
                this.dialogFailInput = true;
              }
            });
        }
      }
    },
    /**
     * Hàm tắt Dialog
     * Author:DTThanh (31/07/2023)
     */
    closeDialog() {
      try {
        this.dialogCode = false;
        this.dialogName = false;
        this.dialogDepartment = false;
        this.dialogHaveCode = false;
        this.dialogFailEmail = false;
        this.dialogFailInput = false;
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Hàm show Fix Menu khi ấn button
     * Author: DTThanh (01/08/2023)
     */
    showFixMenu(id) {
      if (this.employeeIdContextMenu != "") {
        this.employeeIdContextMenu = "";
      } else {
        this.employeeIdContextMenu = id;
      }
      console.log(this.employeeIdContextMenu);
    },

    /**
     * Hàm check định dạng ID
     * Author: DTThanh (27/07/2023)
     */
    formatDateOB(date) {
      return formatDate(date);
    },
    /**
     * Gọi hàm check email
     * Author:DTThanh (02/08/2023)
     */
    checkEmail(email) {
      return isValidEmail(email);
    },
    /**
     * Gọi hàm check ngày tháng
     * Author:DTThanh (03/08/2023)
     */
    checkDate(date) {
      return isValidDate(date);
    },
    /**
     * Hàm show Form Update khi ấn sửa
     * Author: DTThanh (01/08/2023)
     */
    showUpdateEmployeeForm(
      employeeId,
      employeeCode,
      fullName,
      gender,
      identityNumber,
      positionName,
      departmentName,
      dateOfBirth,
      address,
      phoneNumber,
      email,
      indentityPlace,
      identityDate,
    ) {
      try {
        this.formMode = MISAEnum.FORM_MODE.UPDATE;
        this.formUpdate.employeeId = employeeId;
        this.formUpdate.employeeCode = employeeCode;
        this.formUpdate.fullName = fullName;
        this.formUpdate.gender = gender;
        this.formUpdate.identityNumber = identityNumber;
        this.formUpdate.positionName = positionName;
        this.formUpdate.departmentName = departmentName;
        this.formUpdate.dateOfBirth = formatDate1(dateOfBirth);
        this.formUpdate.address = address;
        this.formUpdate.phoneNumber = phoneNumber;
        this.formUpdate.email = email;
        this.formUpdate.indentityPlace = indentityPlace;
        this.formUpdate.identityDate = formatDate1(identityDate);
        this.showForm = true;
        this.$nextTick(() => {
          this.$refs.inputElement.focus();
        });
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Hàm check khi nhập
     */
    inputOnchange() {
      if (this.formUpdate.departmentName!= "") {
        this.textfieldDepartment = false;
      }
      if( this.formUpdate.employeeCode != "" ) {
        this.textfieldCode = false;
      }
      if(this.formUpdate.employeeName != "") {
        this.textfieldName = false;
      }

    },
    /**
         Hàm sửa nhân viên
         DTThanh (08/01/2023)
         */
    updateEmployees() {
      try {
        var errors = [];
        if (
          this.formUpdate.employeeCode === "" ||
          this.formUpdate.fullName === "" ||
          this.formUpdate.departmentName === "" ||
          this.formUpdate.departmentName === null
        ) {
          if (this.formUpdate.employeeCode === "") {
            this.textfieldCode = true;
            this.toastText = `Thêm mới nhân viên thất bại`;
            errors.push("Mã nhân viên không được phép để trống.");

            this.successFailToast = true;

            setTimeout(() => {
              this.failToast = false;
              console.log("s");
            }, 3000);
          } else {
            this.textfieldCode = false;
          }
          if (this.formUpdate.fullName === "") {
            this.textfieldName = true;
            errors.push("Họ và tên không được phép để trống.");
            console.log(errors);
            this.toastText = `Thêm mới nhân viên thất bại`;
            this.successFailToast = true;
            setTimeout(() => {
              this.failToast = false;
              console.log("s");
            }, 3000);
          } else {
            this.textfieldName = false;
          }
          if (
            this.formUpdate.departmentName === "" ||
            this.formUpdate.departmentName === null
          ) {
            this.textfieldDepartment = true;
            this.toastText = `Thêm mới nhân viên thất bại`;
            errors.push("Tên đơn vị không được phép để trống.");
            this.successFailToast = true;
            setTimeout(() => {
              this.failToast = false;
              console.log("s");
            }, 3000);
          } else {
            this.textfieldDepartment = false;
          }
          this.errors = errors;
          this.dialogName = true;
          return;
        }
        if (
          this.formUpdate.employeeCode != "" &&
          this.formUpdate.fullName != "" &&
          this.formUpdate.departmentName != ""
        ) {
          this.textfieldCode = false;
          this.textfieldDepartment = false;
          this.textfieldName = false;
          const employeeData = {
            employeeCode: this.formUpdate.employeeCode,
            fullName: this.formUpdate.fullName,
            gender: 0,
            dateOfBirth: this.formUpdate.dateOfBirth,
            phoneNumber: this.formUpdate.phoneNumber,
            email: this.formUpdate.email,
            address: this.formUpdate.address,
            identityNumber: this.formUpdate.identityNumber,
            identityDate: this.formUpdate.identityDate,
            identityPlace: this.formUpdate.indentityPlace,
            departmentCode: this.formUpdate.positionName,
            departmentName: this.formUpdate.departmentName,
          };
          if (employeeData.email.trim() != "") {
            if (this.checkEmail(employeeData.email) == false) {
              console.log("email sai roi");
              errors.push("Email đã nhập sai định dạng.");
            }
          }
          if (employeeData.dateOfBirth != "") {
            if (this.checkDate(employeeData.dateOfBirth) == false) {
              console.log("ngay lon hon ngay hien tai");
              errors.push("Ngày sinh không được lớn hơn ngày hiện tại.");
            }
          }
          if (employeeData.identityDate != "") {
            if (this.checkDate(employeeData.identityDate) == false) {
              console.log("ngay cap lon hon ngay hien tai");
              errors.push("Ngày cấp không được lớn hơn ngày hiện tại.");
            }
          }
          if (errors.length != 0) {
            this.errors = errors;
            this.dialogFailInput = true;
            return;
          }
          const data = JSON.stringify(this.formUpdate);
          EmployeeService.updateEmployee(this.formUpdate.employeeId, data)
            .then(() => {
              this.toastText = "Chỉnh sửa thông tin thành công";
              this.successAddToast = true;
              setTimeout(() => {
                this.successAddToast = false;
              }, 3000);
              this.getEmployeesData();
              this.showForm = false;
              this.textfieldDepartment = false;
              this.textfieldName = false;
              this.textfieldCode = false;
            })
            .catch((res) => {
              handleApiError(res);
            });
        }
      } catch (error) {
        console.log(error);
      }
    },
    /**
   * Hàm show loading modal
   * Author:DTThanh (07/08/2023)
   */
  showLoadingModal() {
    this.loadingModal = true;
    console.log("show loading modal")
  },
  /**
   * Hàm close Loading Modal
   * Author: DTThanh (07/08/2023)
   */
  closeLoadingModal() {
    this.loadingModal = false;
    console.log("close loading modal")
  },
  /**
   * Hàm reload data
   * Author: DTThanh (08/08/2023)
   */
  async reloadData() {
    try {

        // Gọi hàm getEmployeesData() hoặc bất kỳ hàm nào khác có thể trả về một Promise.
        await this.getEmployeesData();
      } catch (error) {
        // Xử lý lỗi nếu có
        console.error("Lỗi khi lấy dữ liệu:", error);
      } 
  }

  },
  
};
</script>

<style scoped></style>
