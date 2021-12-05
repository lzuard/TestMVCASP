<template>
  <label class="showcase-label-field form-label">
    {{ label }}
    <slot />
  </label>
</template>

<script>
export default {
  name: 'showcase-label-field',
  props: {
    label: {
      type: String,
      require: true
    }
  }
}
</script>
