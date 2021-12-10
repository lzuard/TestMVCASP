<template>
  <div class="col-12 mt-3">
    <layout-button @click="$emit('click')" class="showcase-submit">
      <slot />
    </layout-button>
  </div>
</template>

<script>
import LayoutButton from '@/components/Layouts/layout-button'

export default {
  name: 'showcase-submit-button',
  components: {
    LayoutButton
  },
  emits: ['click']
}
</script>

<style lang="scss">
@import "~@/styles/variables";

@media ($mediaMobile) {
  .showcase-submit {
    width: 100%;
  }
}
</style>
