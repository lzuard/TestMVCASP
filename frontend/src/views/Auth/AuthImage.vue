<template>
  <div class="auth-image col-lg-6 d-flex align-items-center gradient-custom" />
</template>

<script>
export default {
  name: 'AuthImage'
}
</script>

<style lang="scss" scoped>
@import "~@/styles/mixins";

.auth-image {
  background-image: url('~@/assets/images/auth-image.jpg');
  background-position: center center;
  background-size: cover;
  position: relative;
  overflow: hidden;

  &::before {
     position: absolute;
     content: "";
     top: 0;
     left: 0;
     width: 100%;
     height: 100%;
     opacity: 0.6;
     @include cover;
   }
}
</style>
