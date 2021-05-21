<template>
  <div class="dropdown">
    <!-- <div class="dropdown"> -->
    <button class="btn-btn hover padding" @click="btnDropdownClick()">
      <div class="flex btn-btn-text" :class="{ border: valueDrop }">
        <div class="header-icon arrow-up--blue"></div>
      </div>
    </button>
    <!-- </div> -->
    <div class="dropdown-content" :class="{ display: !valueDrop }">
      <div class="dropdown-row-1" @click="btnReplication">Nhân bản</div>
      <div class="dropdown-row-1" @click="btnDelete">Xóa</div>
      <div class="dropdown-row-1">Ngưng sử dụng</div>
    </div>
    <!-- <EmployeeDialog :state="show" /> -->
  </div>
</template>
<script>
// import EmployeeDialog from "./EmployeeDialog.vue"
export default {
  components: {
    // EmployeeDialog
  },
  data() {
    return {
      valueDrop: false, // Giá trị hiển thị dropdown-content

      // showPopup: false,
      // show: false
    };
  },
  methods: {
    /**
     * Click nút nhân bản
     */
    btnReplication() {
      this.$emit("showDialog");
      this.valueDrop = false;
    },
    /* 
    Hiển thị dropdown
    CreatedBy: LMDuc (11/05/2021)
    */
    btnDropdownClick() {
      this.valueDrop = true;
    },

    /* 
    Hiển thị popup
    CreatedBy: LMDuc (11/05/2021)
    */
    btnDelete() {
      this.$emit("showPopup");
      this.valueDrop = false;
    },
  },
  created() {
    /* 
    Phát hiện click chuột thì đóng dropdown
    CreatedBy: LMDuc (11/05/2021)
    */
    window.addEventListener("click", (e) => {
      if (!this.$el.contains(e.target)) {
        this.valueDrop = false;
      }
    });
  },
};
</script>
<style scoped>
.flex {
  display: flex !important;
}
.dropdown {
  position: relative;
}
.dropdown-content {
  position: absolute;
  height: 93px;
  width: 123px;
  right: -10px;
  top: 30px;
  z-index: 200;
  border-radius: 2px;
  background-color: white;
  /* z-index: 1000000; */
  opacity: 1;
  border: 1px solid #bbb;
}
.border {
  border: 1px solid rgb(0, 117, 192);
}
.display {
  display: none;
}
.btn-btn {
  padding: 0 16px;
  border-radius: 30px;
  color: #111;
  height: 36px;
  position: relative;
  border: 1px solid #8d9096;
  background-color: transparent;
  transition: all 0.2s ease;
  cursor: pointer;
  box-sizing: border-box;
  background: 0 0;
  overflow: visible;
  outline: none;
}
.hover {
  border: none;
  padding: 6px 0px 6px 16px;
}
.padding {
  padding: 0 0 0 10px;
}
.btn-btn-text {
  font-weight: 600;
  position: relative;
  color: inherit;
  display: inline-block;
  transition: all 0.25s ease;
  white-space: nowrap;
  font-size: 13px;
  line-height: 13px;
  justify-content: center;
  align-items: center;
}
.header-icon {
  background: url("../../../assets/Sprites.5f05e81f.svg") no-repeat;
  cursor: pointer;
  min-width: 16px;
  min-height: 16px;
  height: 16px;
  width: 16px;
}
.arrow-up--blue {
  background-position: -896px -359px;
}

.dropdown-row-1 {
  height: 32px;
  width: 119px;
  text-align: left;
  padding: 5px 10px;
  box-sizing: border-box;
}
.dropdown-row-1:hover {
  color: #019160;
  background-color: rgb(224, 224, 224);
}
</style>
