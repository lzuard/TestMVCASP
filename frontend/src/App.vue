<template>
  <router-view/>

  <version-caption version="0.1.0" />
</template>

<script>
import VersionCaption from '@/components/UI/versionCaption'

export default {
  components: { VersionCaption }
}
</script>
