<template>
  <div class="showcase-create">
    <header class="showcase-create__header">
      <showcase-title>
        {{ title }}
      </showcase-title>
    </header>
    <div class="showcase-create__fields">
      <div class="row">
        <slot />
      </div>
    </div>
  </div>
</template>

<script>
import ShowcaseTitle from './showcase-title'

export default {
  name: 'showcase-create',
  components: {
    ShowcaseTitle
  },
  props: {
    title: {
      type: String,
      require: true
    }
  }
}
</script>

<style>
.showcase-create {
  text-align: left;
}
</style>
