<template>
  <!-- :class="{'dialog-hide': !state}" -->
  <div class="dialog" v-if="state">
    <div class="model"></div>
    <div class="dialog-box">
      <div class="dialog-header">
        <div class="title flex">
          <div class="title-dialog">Thông tin nhân viên</div>
          <div class="component">
            <input type="checkbox" style="width: 18px; height: 16px" />
            <div style="padding-left: 10px">Là khách hàng</div>
          </div>
          <div class="component">
            <input type="checkbox" style="width: 18px; height: 16px" />
            <div style="padding-left: 10px">Là nhà cung cấp</div>
          </div>
        </div>
      </div>
      <div class="item-close">
        <div class="dialog-icon help" style="margin-right: 6px"></div>
        <div class="dialog-icon close" @click="btnCloseClick"></div>
      </div>
      <div class="dialog-content">
        <div class="employee-inf">
          <div class="inf-left">
            <div class="row-1">
              <div class="code">
                <span class="text"
                  >Mã
                  <p style="color: red; display: inline">*</p></span
                >
                <ValidationProvider
                  name="Mã nhân viên"
                  rules="required"
                  v-slot="{ errors }"
                >
                  <input
                    type="text"
                    :title="errors[0]"
                    maxlength="20"
                    style="width: 155px; margin-top: 4px"
                    v-model="employee.employeeCode"
                    :class="errors[0] == null ? '' : 'input-error'"
                    ref="employeeCode"
                  />
                </ValidationProvider>
              </div>
              <div class="name">
                <span class="text"
                  >Tên
                  <p style="color: red; display: inline">*</p></span
                >
                <ValidationProvider
                  name="Tên nhân viên"
                  rules="required"
                  v-slot="{ errors }"
                >
                  <input
                    type="text"
                    :title="errors[0]"
                    style="width: 235px; margin-top: 4px"
                    v-model="employee.employeeName"
                    :class="errors[0] == null ? '' : 'input-error'"
                    ref="employeeName"
                  />
                </ValidationProvider>
              </div>
            </div>
            <div class="row-1">
              <div class="position">
                <span class="text"
                  >Đơn vị
                  <p style="color: red; display: inline">*</p></span
                >
                <ValidationProvider
                  name="Đơn vị"
                  rules="required"
                  v-slot="{ errors }"
                >
                  <select
                    class="style-title"
                    style="width: 395px; margin-top: 4px"
                    v-model="employee.departmentId"
                    :title="errors[0]"
                    :class="errors[0] == null ? '' : 'input-error'"
                    ref="departmentId"
                  >
                    <option
                      v-for="(department, index) in departments"
                      :key="index"
                      :value="department.departmentId"
                    >
                      {{ department.departmentName }}
                    </option>
                  </select>
                </ValidationProvider>
              </div>
            </div>
            <div class="row-1">
              <div class="position">
                <span class="text">Chức danh</span>
                <input
                  type="text"
                  style="width: 395px; margin-top: 4px"
                  v-model="employee.employeePosition"
                />
              </div>
            </div>
          </div>
          <div class="inf-left">
            <div class="row-1">
              <div class="dateofbirth">
                <span class="text">Ngày sinh</span>
                <input
                  type="date"
                  style="width: 167px; margin-top: 4px"
                  v-model="employee.dateOfBirth"
                />
              </div>
              <div class="gender">
                <span class="text">Giới tính</span>
                <div class="radio" style="width: 251px; margin-top: 4px">
                  <input
                    type="radio"
                    id="male"
                    name="gender"
                    class="input-radio"
                    value="1"
                    v-model="employee.gender"
                  />
                  <label for="male" style="margin-right: 20px">Nam</label>
                  <input
                    type="radio"
                    id="female"
                    name="gender"
                    class="input-radio"
                    value="0"
                    v-model="employee.gender"
                  />
                  <label for="female" style="margin-right: 20px">Nữ</label>
                  <input
                    type="radio"
                    id="other"
                    name="gender"
                    class="input-radio"
                    value="2"
                    v-model="employee.gender"
                  />
                  <label for="other">Khác</label>
                </div>
              </div>
            </div>
            <div class="row-1">
              <div class="id">
                <span class="text">Số CMND</span>
                <input
                  type="text"
                  style="width: 245px; margin-top: 4px"
                  v-model="employee.identityNumber"
                />
              </div>
              <div class="dateofbirth" style="padding-left: 5px">
                <span class="text">Ngày cấp</span>
                <!-- <date-picker v-model="employee.identityDate"  style="width: 167px; margin-top: 4px;box-sizing: border-box; height:32px;"   valueType="token(DD/MM/YYYY)"></date-picker> -->
                <input
                  type="date"
                  style="width: 163px; margin-top: 4px"
                  v-model="employee.identityDate"
                />
              </div>
            </div>
            <div class="row-1">
              <div class="place">
                <span class="text">Nơi cấp</span>
                <input
                  type="text"
                  style="width: 413px; margin-top: 4px"
                  v-model="employee.identityPlace"
                />
              </div>
            </div>
          </div>
        </div>
        <div class="row-1">
          <div class="position" style="margin-top: 17px">
            <span class="text">Địa chỉ</span>
            <input
              type="text"
              style="width: 100%; margin-top: 4px"
              v-model="employee.address"
            />
          </div>
        </div>
        <div class="row-1">
          <div class="phone" style="margin-top: 17px">
            <span class="text">ĐT di động</span>
            <input
              type="text"
              style="width: 197px; margin-top: 4px"
              v-model="employee.phoneNumber"
            />
          </div>
          <div class="phone" style="margin-top: 17px; margin-left: 5px">
            <span class="text">ĐT cố định</span>
            <input
              type="text"
              style="width: 197px; margin-top: 4px"
              v-model="employee.telephoneNumber"
            />
          </div>
          <div class="name" style="margin-top: 17px; margin-left: 5px">
            <span class="text">Email</span><br />
            <input
              type="text"
              style="width: 203px; margin-top: 4px"
              v-model="employee.email"
              @blur="handleBlurEmail($event.target.value)"
            /><br />
            <span style="color: red">{{ messageEmail }}</span>
          </div>
        </div>
        <div class="row-1">
          <div class="phone" style="margin-top: 17px">
            <span class="text">Tài khoản ngân hàng</span>
            <input
              type="text"
              style="width: 197px; margin-top: 4px"
              v-model="employee.bankAccountNumber"
            />
          </div>
          <div class="phone" style="margin-top: 17px; margin-left: 5px">
            <span class="text">Tên ngân hàng</span>
            <input
              type="text"
              style="width: 197px; margin-top: 4px"
              v-model="employee.bankName"
            />
          </div>
          <div class="phone" style="margin-top: 17px; margin-left: 5px">
            <span class="text">Chi nhánh</span>
            <input
              type="text"
              style="width: 203px; margin-top: 4px"
              v-model="employee.bankBranchName"
            />
          </div>
        </div>
      </div>
      <div class="footer">
        <div class="footer-btn">
          <button
            class="add-line"
            style="width: 67px; height: 36px; boder-radius: 4px"
            @click="btnExitClick"
          >
            Hủy
          </button>
          <div class="btn-right">
            <button
              class="add-line"
              style="
                width: 67px;
                height: 36px;
                boder-radius: 4px;
                margin-right: 10px;
              "
              @click="btnSaveClick"
            >
              Cất
            </button>
            <button class="add-line color" @click="btnSaveClickMore">
              Cất và Thêm
            </button>
          </div>
        </div>
      </div>
      <Popup
        v-if="valuePopup"
        @btnYesChangeClick="btnYesChangeClick"
        @hideDialogNotLoad="hideDialogNotLoad"
        @hidePopupNotLoad="valuePopup = false"
        :message="message"
        :messageChange="messageChange"
        :messageCode="messageCode"
      />
    </div>
  </div>
</template>
<script>
import axios from "axios";
import Popup from "./Popup.vue";
// import DatePicker from 'vue2-datepicker';
// import 'vue2-datepicker/index.css';

// import Dropdown from './Dropdown.vue'
const myhost = "https://localhost:44320";

export default {
  components: {
    Popup,
    // DatePicker,
    // Dropdown
  },

  props: {
    state: { type: Boolean, selector: false }, // Trạng thái hiển thị Dialog
    employee: { type: Object, selector: null }, // Đối tượng nhân viên được truyền từ EmployeeList sang
    flag: { type: String, selector: null }, // Cờ để check giá trị nút Thêm mới hay Sửa
    id: null,
    employeeTemp: {},
  },
  data() {
    return {
      messageEmail: null, // Message lỗi
      departments: [], // Mảng phòng ban
      message: null,
      valuePopup: false,
      messageChange: null,
      messageCode: null,
      // showDialog: false
    };
  },

  /**
   * Thực hiện focus vào mã nhân viên
   * CreatedBy: LMDuc (20/05/2021)
   */
  updated() {
    while (this.valueForcusInput === true) {
      if (this.$refs.employeeCode !== undefined) {
        this.$refs.employeeCode.focus();
      }
      this.valueForcusInput = false;
    }
    if (this.state === false) {
      this.valueForcusInput = true;
    }
  },
  methods: {
    /**
     * Click nút Hủy
     * CreatedBy: LMDuc (17/05/2021)
     */
    btnExitClick() {
      this.messageEmail = null;
      this.message = null;
      this.messageCode = null;
      // this.employee = null
      this.$emit("hideDialogNotLoad");
    },
    /**
     * Post dữ liệu lên server
     * CreatedBy: LMDuc (19/05/2021)
     */
    postEmplyee() {
      axios
        .post(myhost + "/api/v1/Employees", this.employee)
        .then((res) => {
          console.log(res.data);
          console.log(this.message);
          this.$emit("hideDialog");
        })
        .catch((res) => {
          // this.message = res.response.data.devMsg;
          this.messageCode =
            "Mã nhân viên <" +
            this.employee.employeeCode +
            "> đã tồn tại trong hệ thống, vui lòng kiểm tra lại.";
          // }
          console.log(res.response.data.devMsg);
          // show popup
          this.valuePopup = true;

          console.log(this.message);
          console.log(this.employee);
          // this.$emit('hideDialog');
        });
    },
    /**
     * Lấy mã nhân viên lớn nhất
     * CreatedBy: LMDuc (19/05/2021)
     */
    getMaxEmployeeCode() {
      //lấy mã nhân viên lớn nhất
      axios
        .get(myhost + "/api/v1/Employees/employeeCode")
        .then((response) => {
          console.log(response.data);
          var increCode = response.data;
          // Cắt chuỗi trả về
          increCode = increCode.substring(3);
          // Gán tất cả các ô data của dialog rỗng
          this.employee = {};
          // Gán code Max cho ô Mã nhân viên
          this.employee.employeeCode = "NV-" + (Number(increCode) + 1);
        })
        .catch((response) => {
          console.log(response);
        });
    },
    /**
     * thực hiện Update dữ liệu
     * CreatedBy: LMDuc(20/05/2021)
     */
    putEmployee() {
      axios
        .put(
          myhost + "/api/v1/Employees/" + this.employee.employeeId,
          this.employee
        )
        .then((res) => {
          console.log(res.data);
          this.$emit("hideDialog");
        })
        .catch((res) => {
          this.messageCode =
            "Mã nhân viên <" +
            this.employee.employeeCode +
            "> đã tồn tại trong hệ thống, vui lòng kiểm tra lại.";
          this.valuePopup = true;
          console.log(res.data);
          console.log(this.employee);
          // this.$emit("hideDialog");
        });
    },
    /**
     * Click nút có ở popup khi thoát mà có sự  thay đổi dữ liệu
     * CreatedBy: LMDuc (18/05/2021)
     * Modified: sử dụng method postEmployee thay vì viết lệnh axios
     * ModifiedBy: LMDuc (19/05/2021)
     */
    btnYesChangeClick() {
      if (this.flag == "edit") {
        this.putEmployee();
      } else {
        this.postEmplyee();
      }
    },
    /* 
    Click đóng Dialog
    CreatedBy: LMDuc (17/05/2021)
    ModifiedBy: LMDuc (20/05/2021)
    */
    btnCloseClick() {
      this.messageEmail = null;
      this.message = null;
      this.messageCode = null;
      this.messageChange = null;
      /**
       * Modified: Click đóng thì kiểm tra thay đổi giữa 2 object
       * - nếu thay đổi thì hiển thị popup và thông báo "Dữ liệu đã bị thay đổi. Bạn có muốn cất không?"
       * - nếu không thay đổi thì đóng popup
       * ModifiedBy: LMDuc (20/05/2021)
       *  */
      if (JSON.stringify(this.employeeTemp) === JSON.stringify(this.employee)) {
        this.$emit("hideDialog");
      } else {
        this.messageChange = "Dữ liệu đã bị thay đổi. Bạn có muốn cất không?";
        this.valuePopup = true;
      }
      //****  End Modified    *********** */
    },
    /* 
    Đóng dialog mà không load lại dữ liệu
    CreatedBy: LMDuc (11/05/2021) 
    */
    hideDialogNotLoad() {
      this.valuePopup = false;
      this.$emit("hideDialogNotLoad");
      this.messageEmail = null;
      this.message = null;
      this.messageCode = null;
      this.messageChange = null;
      this.employee = {};
    },
    /**
     * Kiểm tra emloyee để trống
     * CreatedBy: LMDuc (11/05/2021)
     */
    checkEmployee() {
      if (
        this.employee.employeeCode == "" ||
        this.employee.departmentId == null ||
        this.employee.employeeName == null ||
        this.employee.employeeName == ""
      ) {
        this.message = "";
        if (this.employee.employeeCode == "") {
          this.message = "Mã nhân viên không được để trống";
        } else if (
          this.employee.employeeName == null ||
          this.employee.employeeName == ""
        ) {
          this.message = "Tên không được để trống \n";
          this.$refs.employeeName.focus();
          if (this.employee.departmentId == null) {
            this.$refs.departmentId.focus();
          }
        } else if (this.employee.departmentId == null) {
          this.message += " Không được để trống phòng ban";
          this.$refs.departmentId.focus();
        }

        return true;
      } else return false;
    },

    /**
     * Click nút cất và thêm
     * CreatedBy: LMDuc(17/05/2021)
     * Modified: sử dụng method getMaxEmployeeCode thay vì viết trực tiếp axios lấy mã nhân viên lớn nhất
     * ModifiedBy: LMDuc (19/05/2021)
     */
    btnSaveClickMore() {
      this.messageChange = null;
      this.messageCode = null;
      // kiểm tra các trường bắt buộc nhập
      if (this.checkEmployee()) {
        this.valuePopup = true;
      } else {
        this.message = null;
        axios
          .post(myhost + "/api/v1/Employees", this.employee)
          .then((res) => {
            console.log(res.data);
            console.log(this.message);
            //Modified:
            //lấy mã nhân viên lớn nhất
            this.getMaxEmployeeCode();
            this.employeeTemp = Object.assign({}, this.employee);
          })
          .catch((res) => {
            this.messageCode =
              "Mã nhân viên <" +
              this.employee.employeeCode +
              "> đã tồn tại trong hệ thống, vui lòng kiểm tra lại.";
            console.log(res.response.data.devMsg);
            // show popup
            this.valuePopup = true;
            console.log(this.message);
            console.log(this.employee);
            // this.$emit('hideDialog');
          });
      }
    },
    /*
     * Click nút cất
     * CreatedBy: LMDuc (17/05/2021)
     */
    btnSaveClick() {
      this.messageChange = null;
      this.messageCode = null;
      // kiểm tra các trường bắt buộc nhập
      if (this.checkEmployee()) {
        this.valuePopup = true;
      } else {
        this.message = null;
        //kiểm tra là nút thêm hay sửa
        if (this.flag == "add" || this.flag == "replication") {
          // this.message = ""
          this.postEmplyee();
        }
        // Kiểm tra nút Thêm hay Sửa
        else if (this.flag == "edit") {
          this.putEmployee();
        }
      }
    },

    /* 
    Xử lý blur khỏi Input Email
    CreatedBy: LMDuc (17/05/2021)
    */
    handleBlurEmail(ev) {
      if (
        /^(([^<>()\\.,;:\s@"]+(\.[^<>()\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,24}))$/.test(
          ev
        )
      ) {
        this.messageEmail = "";
      } else {
        this.messageEmail = "Email Không đúng định dạng!";
      }
    },
  },
  mounted: function() {
    axios
      .get(myhost + "/api/v1/Departments")
      .then((res) => {
        this.departments = res.data;
      })
      .catch((res) => {
        console.log(res);
      });
  },
};
</script>
<style scoped>
.flex {
  display: flex !important;
}
.dialog-hide {
  display: none;
}
.dialog {
  border: 1px solid #bbb;
  z-index: 203;
}

.dialog .model {
  width: 100%;
  background: rgba(0, 0, 0, 0.4);
  position: fixed;
  left: 0;
  top: 0;
  height: 100%;
  z-index: 102;
  transition: all 0.25s ease;
  opacity: 1;
}

.dialog .dialog-box {
  z-index: 102;
  border-radius: 4px;
  width: 900px;
  height: 625px;
  position: absolute;
  top: 50%;
  left: 43%;
  transform: translate(-50%, -50%);
  background-color: white;
  box-shadow: 0 5px 20px 0 rgb(0 0 0 / 10%);
}

.dialog-box .dialog-header {
  padding: 20px 12px 20px 32px;
  display: flex;
  align-items: center;
  justify-content: space-between;
  width: 90%;
}
/* .dialog-header .title {
} */
.title-dialog {
  font-size: 24px;
  color: #111111;
}

.style-title:after {
  content: attr(title);
  position: absolute;
  bottom: 100%;
  left: 100%;
  color: #fff;
  background-color: #000;
  padding: 5px;
  display: none;
}
.style-title:hover {
  border: 1px solid #2ca01c;
}
.style-title:hover::after {
  display: block;
  content: attr(title);
  position: absolute;
  bottom: 100%;
  left: 100%;
  color: #fff;
  background-color: #000;
  padding: 5px;
}
.component {
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 0 20px;
}
.item-close {
  position: absolute;
  top: 0;
  right: 0;
  height: 70.4px;
  width: 78px;
  display: flex;
  padding: 12px;
}
.dialog-icon {
  background: url("../../../assets/Sprites.5f05e81f.svg") no-repeat;
  cursor: pointer;
  min-width: 24px;
  min-height: 24px;
  height: 24px;
  width: 24px;
}
.dialog-icon-16 {
  background: url("../../../assets/Sprites.5f05e81f.svg") no-repeat;
  cursor: pointer;
  min-width: 16px;
  min-height: 16px;
  height: 16px;
  width: 16px;
}
.help {
  background-position: -89px -144px;
}
.close {
  background-position: -144px -144px;
}

.dialog-content {
  transition: all 0.23s ease 0.1s;
  flex-direction: column;
  display: flex;
  /* overflow: auto; */
  /* overflow-y: visible; */
  padding: 0 42px 0px 32px;
}
.employee-inf {
  width: 100%;
  display: flex;
  align-items: center;
}
.inf-left {
  padding-bottom: 12px;
  width: 50%;
  height: 100%;
  /* padding: 0 26px 0 0; */
}
.row-1 {
  width: 100%;
  height: 70px;
  display: flex;
}
.code {
  width: 160px;
  height: 70px;
}
.name {
  width: 235px;
  height: 70px;
}
.phone {
  width: 197px;
  height: 70px;
}
.position {
  width: 100%;
  height: 70px;
}
.place {
  width: 418px;
  height: 70px;
}
.text {
  font-weight: 700;
  color: #111111;
}
.dateofbirth {
  width: 170px;
  height: 70px;
}
.gender {
  padding-left: 10px;
  width: 251px;
  height: 70px;
}
.radio {
  display: flex;
  align-items: center;
}

.input-radio {
  width: 20px;
  margin-right: 10px;
}

.select-tab {
  height: 226px;
  width: 100%;
}
.tab {
  height: 32px;
  width: 100%;
  display: flex;
}
.tab-inf {
  height: 192px;
  width: 834px;
  border: 1px solid #c9ccd2;
}
.inf {
  width: 64px;
  height: 100%;
  padding: 0 8px;
  font-size: 13px;
  color: #111111;
  border: none;
  border-top: 1px solid #c9ccd2;
  border-right: 1px solid #c9ccd2;
  border-left: 1px solid #c9ccd2;
  outline: none;
  background-color: white;
}
.inf:hover {
  color: #019160;
}
.bank {
  padding: 0 8px;
  height: 100%;
  width: 148px;
  margin-left: 2px;
  border: none;
  border-top: 1px solid #c9ccd2;
  border-left: 1px solid #c9ccd2;
  border-right: 1px solid #c9ccd2;
  outline: none;
  background-color: white;
}
.bank:hover {
  color: #019160;
}
.content-tblEmployee {
  height: 145px;
  overflow-y: auto;
}
.delete {
  background-position: -464px -312px;
}
.add-line {
  border: 1px solid #c9ccd2;
  width: 109px;
  height: 24px;
  background-color: white;
  font-weight: 700;
  border-radius: 4px;
  /* margin-left: 20px; */
  cursor: pointer;
}

.footer {
  height: 89px;
  /* width: 100%; */
  position: absolute;
  bottom: 0;
  right: 32px;
  left: 32px;
  line-height: 89px;
}

.footer-btn {
  display: flex;
  border-top: 1px solid #e0e0e0;
  margin: auto;
  align-items: center;
  justify-content: space-between;
}
.color {
  height: 36px;
  color: white;
  background-color: #35bf22;
  border-radius: 4px;
  border: none;
  outline: none;
}
.color:hover {
  background-color: #3ff128;
}
.input-error {
  border: 1px solid red;
}
</style>
