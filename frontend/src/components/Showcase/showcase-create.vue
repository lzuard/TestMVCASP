<template>
  <div class="showcase-create">
    <header class="showcase-create__header">
      <showcase-title>
        {{ title }}
      </showcase-title>
    </header>
    <div class="showcase-create__fields">
      <div class="row">
        <showcase-label-field
          v-for="(item, index) in fields"
          :class="[item.cols && item.cols.length ? item.cols.join(' ') : 'col-md-6']"
          :key="index"
          :label="item.label"
        >
          <component
            :is="getComponentWithType(item.type)"
            :type="item.type ?? 'text'"
            v-model="dataToSend[item.modelValue]"
            :placeholder="item.placeholder"
            :is-error="hasError(item.modelValue)"
            :error-text="getErrorText(item.modelValue)"
            :values="item.values ?? null"
          />
        </showcase-label-field>

        <showcase-submit @click="onSend">
          <edit-icon />
          Создать
        </showcase-submit>
      </div>
    </div>
  </div>
</template>

<script>
import { useVuelidate } from '@vuelidate/core'
import ShowcaseTitle from './showcase-title'
import ShowcaseLabelField from './showcase-label-field'
import ShowcaseSubmit from './showcase-submit-button'
import { EditIcon } from '@iconicicons/vue3'
import InputField from '@/components/UI/inputField'
import SelectField from '@/components/UI/selectField'
import TextareaField from '@/components/UI/textareaField'

export default {
  name: 'showcase-create',
  components: {
    TextareaField,
    InputField,
    SelectField,
    ShowcaseLabelField,
    ShowcaseSubmit,
    ShowcaseTitle,
    EditIcon
  },
  setup () {
    return { v$: useVuelidate({ $autoDirty: true }) }
  },
  validations () {
    return {
      dataToSend: {
        ...Object.keys(this.dataToSend).reduce((result, key, index) => {
          result[key] = { ...this.fields[index].validation }
          return result
        }, {})
      }
    }
  },
  props: {
    title: {
      type: String,
      require: true
    },
    fields: {
      type: Array,
      default: () => ([])
    }
  },
  data: () => {
    return {
      dataToSend: {}
    }
  },
  created () {
    this.dataToSend = {
      ...this.fields.reduce((result, current) => {
        result[current.modelValue] = ''
        return result
      }, {})
    }
  },
  emits: ['onSend'],
  methods: {
    async onSend () {
      const isReady = await this.v$.$validate()

      if (isReady) {
        this.$emit('onSend', this.dataToSend)
      }
    },

    hasError (field) {
      return Boolean(this.v$.dataToSend[field].$errors && this.v$.dataToSend[field].$errors.length)
    },

    getErrorText (field) {
      return this.hasError(field) ? this.v$.dataToSend[field].$errors[0].$message : ''
    },

    clearForm () {
      Object.keys(this.dataToSend).forEach((key) => {
        this.dataToSend[key] = ''
      })

      this.v$.$reset()
    },

    getComponentWithType (type) {
      if (type === 'select') return 'select-field'

      if (type === 'textarea') return 'textarea-field'

      return 'input-field'
    }
  }
}
</script>

<style>
.showcase-create {
  text-align: left;
}
</style>
