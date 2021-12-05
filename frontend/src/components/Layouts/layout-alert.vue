<template>
  <div class="alert-wrapper">
    <div
      :class="[
      'alert',
      `alert-${type}`
    ]"
      role="alert"
    >
      <slot />
    </div>
  </div>
</template>

<script>
export default {
  name: 'alert',
  props: {
    type: {
      type: String,
      default: 'primary',
      validate (value) {
        return ['primary', 'secondary', 'success', 'danger', 'warning', 'info'].includes(value)
      }
    }
  }
}
</script>

<style lang="scss" scoped>
  .alert-wrapper {
    padding: 10px 0;

    .alert {
      padding: 10px 10px;
      margin-bottom: 0;
    }
  }
</style>
