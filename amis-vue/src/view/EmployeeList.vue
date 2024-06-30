<template>
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
              />
              <span @click="getFilterEmployee(filterText)"
                ><i class="fa-solid fa-magnifying-glass"></i
              ></span>
            </div>
          </div>
          <div class="icon icon-reload" @click="getEmployeesData()"></div>
        </div>
        <div class="container-content-table m-table">
          <table>
            <thead>
              <tr class="table-head">
                <th class="text-align-center"><input type="checkbox" /></th>
                <th class="text-align-left">MÃ NHÂN VIÊN</th>
                <th class="text-align-left mw-200" style="max-width:340px;overflow: hidden;">TÊN NHÂN VIÊN</th>
                <th class="text-align-left">GIỚI TÍNH</th>
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
</template>
<script>
</script>
<style></style>