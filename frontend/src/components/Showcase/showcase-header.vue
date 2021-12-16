<template>
  <header class="showcase-header">
    <showcase-title>
      {{ title }}
    </showcase-title>
    <router-link class="link showcase-header__create" :to="linkToCreate">
      <file-plus-icon />
      {{ createCaption }}
    </router-link>
  </header>
</template>

<script>
import ShowcaseTitle from './showcase-title'
import { FilePlusIcon } from '@iconicicons/vue3'

export default {
  name: 'showcase-header',
  components: {
    ShowcaseTitle,
    FilePlusIcon
  },
  props: {
    title: {
      type: String,
      require: true
    },
    linkToCreate: {
      type: String,
      require: true
    },
    createCaption: {
      type: String,
      require: true
    }
  }
}
</script>

<style lang="scss">
.showcase-header {
  &__create {
     font-weight: 600;
     display: inline-flex;
   }
}
</style>
