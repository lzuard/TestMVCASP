<template>
  <div
    :class="[
      'preloader',
      {
       'preloader--with-cover': withCover
      }
    ]"
  >
    <svg
      xmlns="http://www.w3.org/2000/svg"
      :width="width"
      :height="height"
      viewBox="0 0 128 128"
      xml:space="preserve">
      <g>
        <path d="M64 128A64 64 0 0 1 18.34 19.16L21.16 22a60 60 0 1 0 52.8-17.17l.62-3.95A64 64 0 0 1 64 128z" />
        <animateTransform attributeName="transform" type="rotate" from="0 64 64" to="360 64 64" dur="1800ms" repeatCount="indefinite" />
      </g>
    </svg>
  </div>
</template>

<script>
export default {
  name: 'Preloader',
  props: {
    withCover: {
      type: Boolean,
      default: false
    },
    width: {
      type: Number,
      default: 48
    },
    height: {
      type: Number,
      default: 48
    }
  }
}
</script>

<style lang="scss" scoped>
@import "~@/styles/variables";

.preloader {
  display: flex;
  justify-content: center;

  &--with-cover {
    position: absolute;
    top: 0;
    left: 0;
    bottom: 0;
    right: 0;
    display: flex;
    justify-content: center;
    align-items: center;
    background-color: rgba($grey, .8);

    svg path {
      fill: $blue;
    }
  }
}
</style>
