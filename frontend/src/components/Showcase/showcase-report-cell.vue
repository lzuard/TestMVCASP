<template>
  <div class="col-12 showcase-report-cell">
    <frame-decorator :title="title">
      <slot />
    </frame-decorator>
  </div>
</template>

<script>
import FrameDecorator from '@/components/UI/frameDecorator'

export default {
  name: 'showcase-report-cell',
  components: {
    FrameDecorator
  },
  props: {
    title: {
      type: String,
      require: true
    }
  }
}
</script>

<style lang="scss">
.showcase-report-cell {
  margin-bottom: 30px;
}
</style>
