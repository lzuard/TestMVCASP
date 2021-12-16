<template>
  <div class="frame">
    <span v-if="title" class="frame__title">
      {{ title }}
    </span>
    <div class="frame__content">
      <slot />
    </div>
  </div>
</template>

<script>
export default {
  name: 'frameDecorator',
  props: {
    title: {
      type: String,
      default: ''
    },
    isVertical: {
      type: Boolean,
      default: false
    }
  }
}
</script>

<style lang="scss">
@import "~@/styles/variables";

.frame {
  border-radius: 10px;
  border: 3px solid $blue;
  padding: 10px;
  position: relative;

  &__title {
    position: absolute;
    font-size: $font-size-xs;
    top: -14px;
    left: 20px;
    background-color: $grey;
    padding: 0 5px;
    color: $blue;
    font-weight: 600;
    max-width: calc(100% - 35px);
  }

  &__content {
    padding: $gap-s;
  }
}
</style>
