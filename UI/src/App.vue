<template>
  <div id="app">
    <TheNavBar />
    <TheHeader />
    <TheContent />
  </div>
</template>

<script>
import TheNavBar from "./components/layouts/TheNavBar.vue";
import TheHeader from "./components/layouts/TheHeader.vue";
import TheContent from "./components/layouts/TheContent.vue";

export default {
  name: "App",
  components: {
    TheNavBar,
    TheHeader,
    TheContent,
  },
};
</script>

<style>
@import "./components/styles/main.css";
@import "./components/styles/input.css";
@import "./components/styles/table.css";
@import "./components/styles/dropdown.css";

/* ::-webkit-scrollbar{
  width: 8px;
  display: block;
  height: 8px;
  color: #000;
} */
</style>
