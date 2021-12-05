<template>
  <button
    class="btn btn-primary"
    :class="[
      'btn',
      'btn-primary',
      {
        'gradient-custom': isGradient
      }
    ]"
    type="button"
  >
    <slot />
  </button>
</template>

<script>
export default {
  name: 'layout-button',
  props: {
    isGradient: {
      type: Boolean,
      default: false
    }
  }
}
</script>
