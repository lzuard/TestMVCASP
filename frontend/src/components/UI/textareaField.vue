<template>
  <div class="textarea-field">
    <textarea
      :class="[
        'form-control',
        {
          'is-invalid': isError
        }
      ]"
      :value="modelValue"
      @input="$emit('update:modelValue', $event.target.value)"
    >
    </textarea>

    <span
      v-if="isError"
      class="input-error-caption input-error-caption--textarea"
    >
      {{ errorText }}
    </span>
  </div>
</template>

<script>
export default {
  name: 'textareaField',
  emits: ['update:modelValue'],
  props: {
    placeholder: {
      type: String,
      default: ''
    },
    modelValue: {
      type: String,
      default: ''
    },
    isError: {
      type: Boolean,
      default: false
    },
    errorText: {
      type: String,
      default: ''
    }
  }
}
</script>

<style>
.textarea-field {
  position: relative;
  resize: none;
}
</style>
