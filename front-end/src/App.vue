<template>
  <div>
    <TheHeader></TheHeader>
    <TheNav></TheNav>
    <TheContainer></TheContainer>
  </div>
</template>

<script>
import TheContainer from "./components/layout/TheContainer.vue";
import TheHeader from "./components/layout/TheHeader.vue";
import TheNav from "./components/layout/TheNav.vue";
// import TheDialog from './components/layout/TheDialog.vue'
export default {
  name: "App",
  components: { TheContainer, TheNav, TheHeader },
};
</script>
<style>
#app {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}
</style>
