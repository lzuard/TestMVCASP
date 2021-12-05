<template>
  <div class="showcase-title">
    <slot />
  </div>
</template>

<script>
export default {
  name: 'showcase-title'
}
</script>

<style lang="scss">
@import "~@/styles/variables";

.showcase-title {
  font-weight: 700;
  font-size: $font-size-xl;
  line-height: $lh-xl;
  margin: $gap-m 0;

  @media ($mediaMobile) {
    font-size: $font-size-l;
    line-height: $lh-l;
    margin: $gap-s 0;
  }
}
</style>
