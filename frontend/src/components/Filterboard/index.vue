<template>
  <div class="filter">
    <span v-if="title" class="filter__title">
      {{ title }}
    </span>
    <div class="filter__items">
      <slot />
    </div>
  </div>
</template>

<script>
export default {
  name: 'Filterboard',
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

.filter {
  border-radius: 10px;
  border: 3px solid $blue;
  padding: 10px;
  position: relative;

  &__title {
    position: absolute;
    font-size: $font-size-xs;
    top: -14px;
    left: 10px;
    background-color: $grey;
    padding: 0 5px;
    color: $blue;
    font-weight: 600;
  }

  &__items {
    display: flex;
    flex-wrap: wrap;
    align-items: end;

    & > *:not(:last-child) {
      margin-right: 15px;
      margin-bottom: 5px;
    }
  }
}
</style>
