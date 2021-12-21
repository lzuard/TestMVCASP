<template>
  <div class="version">
    Продукт находится в режиме тестирования,
    по вопросам обслуживания обращаться по адресу <a href="mailto:sasha.20133@gmail.com">support.warehouse@gmail.com</a>
  </div>

  <div v-bind="$attrs" class="version-caption">
    v{{ version }}
  </div>
</template>

<script>
export default {
  name: 'versionCaption',

  props: {
    version: {
      type: String,
      required: true
    }
  }
}
</script>

<style lang="scss" scoped>
  @import "~@/styles/variables";

  .version-caption {
    position: absolute;
    top: 5px;
    right: 10px;
    text-align: right;
    color: $blue;
    font-weight: 600;
    font-size: 12px;
  }

  .version {
    width: 100%;
    color: $blue;
    font-weight: 600;
    padding: $gap-xs;
    font-size: 11px;
    position: fixed;
    left: 50%;
    transform: translateX(-50%);
    bottom: 0;
    background-color: $grey;

    a {
      text-decoration: underline;
    }
  }
</style>
