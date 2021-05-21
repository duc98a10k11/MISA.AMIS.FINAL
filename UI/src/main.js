import Vue from "vue";
import App from "./App.vue";
import VueRouter from "vue-router";
import EmployeeList from "./components/views/employee/EmployeeList.vue";
import "../src/assets/font/fontawesome-5.15.1/css/all.min.css";
import { ValidationProvider, extend } from "vee-validate";
import vSelect from "vue-select";

extend("required", {
  validate(value) {
    return {
      required: true,
      valid: ["", null, undefined].indexOf(value) === -1,
    };
  },
  computesRequired: true,
  message: "{_field_} không thể để trống",
});

Vue.component("ValidationProvider", ValidationProvider);
Vue.component("v-select", vSelect);
Vue.config.productionTip = false;
Vue.use(VueRouter);

const routes = [{ path: "/employee", component: EmployeeList }];

const router = new VueRouter({
  routes,
});

Vue.filter("dateFormatDDMMYY", function(date) {
  if (date == null) return "";
  if (date == "0001-01-01T00:00:00") return "";
  var newDate = new Date(date);
  var day = newDate.getDate();
  var month = newDate.getMonth() + 1;
  var year = newDate.getFullYear();
  day = day < 10 ? "0" + day : day;
  month = month < 10 ? "0" + month : month;
  return `${day}/${month}/${year}`;
});

Vue.filter("showDepartment", function(value) {
  if (!value) return "";
  if (value == "11452b0c-768e-5ff7-0d63-eeb1d8ed8cef") {
    return "Phòng nhân sự";
  } else if (value == "142cb08f-7c31-21fa-8e90-67245e8b283e") {
    return "Phòng marketing";
  } else if (value == "17120d02-6ab5-3e43-18cb-66948daf6128") {
    return "Phòng kế toán";
  } else if (value == "469b3ece-744a-45d5-957d-e8c757976496") {
    return "Phòng nghiên cứu";
  } else if (value == "4e272fc4-7875-78d6-7d32-6a1673ffca7c") {
    return "Phòng đào tạo";
  }
});

new Vue({
  render: (h) => h(App),
  router,
}).$mount("#app");
