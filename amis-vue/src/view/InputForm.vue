<template>
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
              <label>Mã nhân viên <span class="require">*</span></label>
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
</template>
  <script></script>
  <style></style>