<template>
  <div class="col-12 showcase-report-cell">
    <filterboard :title="title">
      <slot />
    </filterboard>
  </div>
</template>

<script>
import Filterboard from '@/components/Filterboard'

export default {
  name: 'showcase-report-cell',
  components: {
    Filterboard
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
