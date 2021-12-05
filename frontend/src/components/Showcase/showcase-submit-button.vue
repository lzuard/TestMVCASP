<template>
  <div class="col-12 mt-3">
    <layout-button class="showcase-submit">
      <slot />
    </layout-button>
  </div>
</template>

<script>
import LayoutButton from '@/components/layouts/layout-button'

export default {
  name: 'showcase-submit-button',
  components: {
    LayoutButton
  }
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
