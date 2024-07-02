<template>
    <div :class="buttonClass"> {{ buttonText }}</div>
</template>
<script>
export default {
    name: "TheButton",
    props: {
        buttonClass: String,
        buttonText: String
    },
    methods: {
        clickButton() {
            this.$emit(this.clickButton);
        }
    },
}
</script>
<style></style>