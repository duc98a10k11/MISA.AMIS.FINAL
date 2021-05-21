<template>
  <div class="header">
    <div class="header-left">
      <div class="header-icon three-tripes"></div>
      <div class="flex header-branch">
        <div class="header-branch-name">
          CÔNG TY TNHH SẢN SUẤT - THƯƠNG MẠI - DỊCH VỤ QUI PHÚC
        </div>
        <div class="header-icon chevron-right"></div>
      </div>
      <!-- <div class="flex db-content">
                <div class="db-icon"></div>
                <div class="db-name">DC-01</div>
            </div> -->
    </div>
    <div class="header-right">
      <button class="button">
        <div class="flex button-text">
          <div class="header-icon bell__nav"></div>
        </div>
      </button>
      <div class="flex header-branch">
        <div class="header-icon user-avatar"></div>
        <div class="header-branch-name">Lê Minh Đức</div>
        <div class="header-icon chevron-right"></div>
      </div>
    </div>
  </div>
</template>
<script>
export default {};
</script>
<style scoped>
.header {
  position: absolute;
  top: 0;
  left: 178px;
  width: calc(100% - 178px);
  height: 48px;
  display: flex !important;
  align-items: center;
  justify-content: space-between;
}
.header .header-left {
  display: flex;
  align-items: center;
  line-height: 32px;
  box-sizing: border-box;
}
.header .header-right {
  display: flex;
  align-items: center;
  line-height: 32px;
  margin-right: 16px;
  box-sizing: border-box;
}
.header-icon {
  background: url("../../assets/Sprites.5f05e81f.svg") no-repeat;
  cursor: pointer;
  min-width: 24px;
  min-height: 24px;
  height: 24px;
  width: 24px;
  margin-left: 8px;
  margin-right: 8px;
}
.header .header-branch {
  display: flex;
  align-items: center;
  cursor: pointer;
}
.header-branch-name {
  font-size: 13px;
  line-height: 32px;
}
.header .db-content {
  border: 1px solid #ebedf0;
  padding: 0 12px;
  border-radius: 40px;
  margin-left: 15px;
  font-size: 13px;
  cursor: pointer;
  height: 30px;
  margin-right: 10px;
}
.db-content .db-icon {
  width: 8px;
  height: 8px;
  background-color: #4ea344;
  border-radius: 50%;
  border: 1px solid #fff;
}
.db-content .db-name {
  max-width: 80px;
  padding-left: 7px;
  max-width: 200px;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
  transition: all 0.2s ease;
  color: #111;
}
.three-tripes {
  background-position: -843px -30px;
}
.chevron-right {
  background-position: -76px -357px;
  transform: rotate(90deg);
}
.flex {
  display: flex;
  align-items: center;
}
.header .space-beetween {
  width: 20%;
}
.header .header-input {
  height: 32px;
  display: flex;
  align-items: center;
}
.margin {
  margin-right: 10px;
}
.button {
  height: 100%;
  position: relative;
  transition: all 0.2s ease;
  border: 0;
  width: 44px;
  cursor: pointer;
  position: relative;
  overflow: hidden;
  color: #fff;
  box-sizing: border-box;
  background: 0 0;
  overflow: visible;
}
.button-text {
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
.category {
  background-position: -568px -30px;
}
.setting__nav {
  background-position: -675px -30px;
}
.chat__nav {
  background-position: -899px -30px;
}
.help__nav {
  background-position: -731px -30px;
}
.bell__nav {
  background-position: -788px -30px;
}
.user-avatar {
  background-position: -352px -894px;
  width: 32px;
  height: 32px;
  border-radius: 50%;
}
@media screen and (max-width: 1024px) {
  .input-search {
    width: 100px;
  }
}
</style>
