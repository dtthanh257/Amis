import { createApp } from "vue";
import format from "./helper/format";
import isValidCheck from "./helper/isValidCheck.js";
import MISAEnum from "./helper/enum";
import App from "./App.vue";
import "@/css/main.css";
const app = createApp(App);
app.mount("#app");
app.config.globalProperties.$format = format;
app.config.globalProperties.$MISAEnum = MISAEnum;