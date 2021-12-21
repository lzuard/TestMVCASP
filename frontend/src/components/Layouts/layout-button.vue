<template>
  <button
    class="btn"
    :class="[
      ...additionalClasses,
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
    },
    state: {
      type: Array,
      default: () => (['primary'])
    }
  },
  computed: {
    additionalClasses () {
      return this.state.map(item => `btn-${item}`)
    }
  }
}
</script>
