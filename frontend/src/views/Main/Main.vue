<template>
  <div class="main">
    <div class="main__sidebar">
      <navbar />
    </div>
    <div class="main__body">
      <router-view />
    </div>
  </div>
</template>

<script>
import Navbar from '@/components/Sidebar'

export default {
  name: 'Main',
  components: {
    Navbar
  }
}
</script>

<style lang="scss">
@import "~@/styles/variables";

.main {
  display: flex;

  &__sidebar {
    max-width: $sidebarWidth;
    height: 100vh;
    position: sticky;
    top: 0;
    bottom: 0;

    @media ($mediaMobile) {
      position: absolute;
      left: -$sidebarWidth;
    }
  }

  &__body {
    flex-grow: 1;
    padding: $gap-m;
    overflow-y: scroll;
  }
}
</style>
