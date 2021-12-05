<template>
  <div class="input-field">
    <input
      class="form-control"
      :placeholder="placeholder"
      :type="type"
      :value="modelValue"
      @input="$emit('update:modelValue', $event.target.value)"
    />
  </div>
</template>

<script>
export default {
  name: 'InputField',
  props: {
    type: {
      type: String,
      default: 'text',
      validation (value) {
        return ['text', 'number', 'date', 'password'].includes(value)
      }
    },

    placeholder: {
      type: String,
      require: true
    },

    modelValue: {
      type: String,
      default: ''
    }
  },
  emits: ['update:modelValue']
}
</script>
