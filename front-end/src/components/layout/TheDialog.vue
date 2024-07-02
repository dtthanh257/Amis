<template>
  <div id="dialogName" class="dialog-modal">
    <div class="dialog">
      <div class="dialog-header d-flex-row mb-24">
        <h3 class="dialog-title">{{ dialogTitle }}</h3>
      </div>
      <div class="dialog-content d-flex-row mb-24">
        <div
          :class="{
            'icon-dialog-error icon': !dialogHaveCode,
            'icon-dialog-warning icon': dialogHaveCode,
          }"
        ></div>
        <div class="dialog-discr">
          <li :style="listStyle" v-for="(msg, index) in errors" :key="index">
            {{ msg }}
          </li>
        </div>
      </div>
      <div class="dialog-bottom d-flex-row gap-8">
        <button class="btn btn-sec" @click="closeDialog()">Đóng</button>

        <button class="btn btn-pri" @click="closeDialog()">Đồng ý</button>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "TheDialog",
  props: ["dialogText", "dialogTitle", "dialogHaveCode", "errors"],
  methods: {
    closeDialog() {
      try {
        this.$emit("close-dialog");
        console.log(this.dialogText);
      } catch (error) {
        console.log(error);
      }
    },
  },
  computed: {
    listStyle() {
      if (this.errors.length === 1) {
        return {
          "list-style-type": "none",
        };
      } else {
        return {};
      }
    },
  },
};
</script>
<style></style>
