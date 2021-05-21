<template>
  <!-- :class="{'display': popState}" -->
  <div class="popup" :class="{ display: popState }">
    <div class="model"></div>
    <div class="popup-box">
      <div class="popup-content">
        <div
          v-if="employeeClickCode != null"
          class="popup-icon exclamation-warning-48"
        ></div>
        <div v-if="employeeClickCode != null" class="message">
          Bạn có thực sự muốn xóa Nhân viên &lt;{{ employeeClickCode }}&gt;
          không?
        </div>

        <div
          v-if="messageCode != null"
          class="popup-icon exclamation-warning-48"
        ></div>
        <div v-if="messageCode != null" class="message">{{ messageCode }}</div>

        <div
          v-if="message != null"
          class="popup-icon mi-exclamation-error-48-2"
        ></div>
        <div v-if="message != null" class="message">{{ message }}</div>
        <div v-if="messageChange != null" class="popup-icon icon-change"></div>
        <div v-if="messageChange != null" class="message">
          {{ messageChange }}
        </div>
      </div>
      <div class="btn-footer">
        <button
          v-if="employeeClickCode != null"
          class="btn-No"
          @click="btnNoClick"
        >
          Không
        </button>
        <button
          v-if="employeeClickCode != null"
          class="btn-yes"
          @click="btnYesClick"
        >
          Có
        </button>

        <button
          v-if="message != null"
          class="btn-close"
          @click="btnNoClick"
          style="margin: auto;"
        >
          Đóng
        </button>

        <button
          v-if="messageCode != null"
          class="btn-close"
          @click="btnNoClick"
          style="margin-left: 291px;"
        >
          Đồng ý
        </button>

        <button v-if="messageChange != null" class="btn-No" @click="btnNoClick">
          Hủy
        </button>
        <div v-if="messageChange != null">
          <button
            v-if="messageChange != null"
            class="btn-No"
            style="margin-right: 10px;"
            @click="btnNotSaveClick"
          >
            Không
          </button>
          <button
            v-if="messageChange != null"
            class="btn-yes"
            @click="btnYesChangeClick()"
          >
            Có
          </button>
        </div>
      </div>
    </div>
    <!-- <EmployeeDialog   :state="show"
        /> -->
  </div>
</template>
<script>
import axios from "axios";
// import EmployeeDialog from "../employee/EmployeeDialog.vue"

const myhost = "https://localhost:44320";
export default {
  components: {
    // EmployeeDialog
  },
  data() {
    return {
      // show: false
    };
  },
  props: {
    popState: { type: Boolean, selector: false },
    employeeClickCode: { type: String, selector: null },
    employeeClickId: { type: String, selector: null },
    message: { type: String, selector: null },
    messageChange: { type: String, selector: null },
    messageCode: { type: String, selector: null },
    employee: {},
  },
  methods: {
    /**
     * Tắt popup mà không thực hiện gì
     * CreatedBy: LMDuc (17/05/2021)
     */
    btnNoClick() {
      // this.messageChange = null;
      this.$emit("hidePopupNotLoad");

      // this.$emit('hideDialogNotLoad');
    },
    /**
     * Chức năng tắt không lưu khi dữ liệu trong EmployeeDialog bị thay đổi
     * CreatedBy: LMDuc (18/05/2021)
     */
    btnNotSaveClick() {
      this.$emit("hideDialogNotLoad");
    },
    /**
     *
     */
    btnYesChangeClick() {
      this.$emit("btnYesChangeClick");
      this.$emit("hideDialogNotLoad");
    },
    btnYesClick() {
      axios
        .delete(myhost + "/api/v1/Employees/" + this.employeeClickId)
        .then((res) => {
          console.log(res);
          this.$emit("hidePopup");
        })
        .catch((res) => {
          console.log(res);
        });
    },
  },
};
</script>
<style scoped>
.popup {
}
.popup .model {
  width: 100%;
  background: rgba(0, 0, 0, 0.4);
  position: fixed;
  left: 0;
  top: 0;
  height: 100%;
  z-index: 103;
  transition: all 0.25s ease;
  opacity: 1;
}
.popup .popup-box {
  border-radius: 4px;
  width: 444px;
  height: 203px;
  position: absolute;
  top: 50%;
  left: 43%;
  transform: translate(-50%, -50%);
  background-color: white;
  box-shadow: 0 5px 20px 0 rgb(0 0 0 / 10%);
  padding: 32px;
  z-index: 105;
}
.popup-content {
  display: flex;
  width: 100%;
  height: 82px;
  align-items: center;
  border-bottom: 1px solid #bbb;
  margin-bottom: 20px;
}
.popup-icon {
  background: url("../../../assets/Sprites.5f05e81f.svg") no-repeat;
  cursor: pointer;
  min-width: 48px;
  min-height: 48px;
  height: 48px;
  width: 48px;
}
.exclamation-warning-48 {
  background-position: -592px -456px;
}
.message {
  padding: 12px 0 0 16px;
  display: block;
  margin-bottom: 32px;
}
.btn-footer {
  display: flex;
  align-items: center;
  justify-content: space-between;
}
.btn-No {
  height: 36px;
  width: 84px;
  outline: none;
  border: 1px solid rgb(71, 71, 71);
  padding: 8px 20px;
  background-color: white;
  border-radius: 4px;
  font-weight: 700;
}
.btn-No:hover {
  background-color: rgb(202, 202, 202);
}
.btn-yes {
  width: 59px;
  height: 36px;
  background-color: #2ca01c;
  border: none;
  color: white;
  outline: none;
  border-radius: 4px;
  font-weight: 700;
  padding: 8px 20px;
}
.btn-close {
  /* width: 76px; */
  height: 36px;
  background-color: #2ca01c;
  border: none;
  color: white;
  outline: none;
  border-radius: 4px;
  font-weight: 700;
  padding: 8px 20px;
}
.display {
  display: none;
}
.mi-exclamation-error-48-2 {
  background-position: -24px -954px;
}
.icon-change {
  background-position: -592px -456px;
}
</style>
