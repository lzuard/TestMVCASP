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
      </div>

      <div
        v-if="enableAddedFields"
        class="row showcase-create__added-fields"
      >
        <h4 class="col-12">{{ subtitle }}</h4>

        <div
          class="col-12 py-2 showcase-create__added-fields-row"
          v-for="(outerItem, key) in additionalItems"
          :key="key"
        >
          <div class="row">
            <showcase-label-field
              v-for="(item, index) in addedFields"
              :class="[item.cols && item.cols.length ? item.cols.join(' ') : 'col-md-6']"
              :key="index"
              :label="item.label"
            >
              <component
                :is="getComponentWithType(item.type)"
                :type="item.type ?? 'text'"
                v-model="outerItem[item.modelValue]"
                :placeholder="item.placeholder"
                :values="item.values ?? null"
              />
            </showcase-label-field>
          </div>

          <layout-button :state="['danger']" v-if="key !== 0" @click="deleteAdditionalItem(key)">
            <close-icon />
            Удалить
          </layout-button>
        </div>

        <showcase-submit @click="addItem">
          <plus-icon />
          Добавить ещё
        </showcase-submit>
      </div>

      <showcase-submit @click="onSend">
        <floppy-disc-icon />
        Сохранить
      </showcase-submit>
    </div>
  </div>
</template>

<script>
import { useVuelidate } from '@vuelidate/core'
import ShowcaseTitle from './showcase-title'
import ShowcaseLabelField from './showcase-label-field'
import ShowcaseSubmit from './showcase-submit-button'
import { FloppyDiscIcon, PlusIcon, CloseIcon } from '@iconicicons/vue3'
import InputField from '@/components/UI/inputField'
import SelectField from '@/components/UI/selectField'
import TextareaField from '@/components/UI/textareaField'
import LayoutButton from '@/components/Layouts/layout-button'

export default {
  name: 'showcase-create',
  components: {
    LayoutButton,
    TextareaField,
    InputField,
    SelectField,
    ShowcaseLabelField,
    ShowcaseSubmit,
    ShowcaseTitle,
    FloppyDiscIcon,
    CloseIcon,
    PlusIcon
  },
  setup () {
    return { v$: useVuelidate({ $autoDirty: true }) }
  },
  validations () {
    return {
      dataToSend: {
        ...Object.keys(this.dataToSend).reduce((result, current) => {
          result[current] = { ...this.fields.find(item => item.modelValue === current).validation }
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
    },
    enableAddedFields: {
      type: Boolean,
      default: false
    },
    subtitle: {
      type: String,
      default: ''
    },
    addedFields: {
      type: Array,
      default: () => ([])
    }
  },
  data: () => {
    return {
      dataToSend: {},
      additionalItems: [{}]
    }
  },
  created () {
    this.dataToSend = {
      ...this.fields.reduce((result, current) => {
        result[current.modelValue] = null
        return result
      }, {})
    }
  },
  emits: ['onSend'],
  methods: {
    async onSend () {
      const isReady = await this.v$.$validate()

      if (isReady && this.enableAddedFields) {
        this.$emit('onSend', this.dataToSend, this.additionalItems)
      } else if (isReady) {
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

      if (this.enableAddedFields) {
        this.additionalItems = [{}]
      }

      this.v$.$reset()
    },

    getComponentWithType (type) {
      if (type === 'select') return 'select-field'

      if (type === 'textarea') return 'textarea-field'

      return 'input-field'
    },

    addItem () {
      this.additionalItems.push({})
    },

    deleteAdditionalItem (index) {
      this.additionalItems.splice(index, 1)
    }
  }
}
</script>

<style lang="scss">
@import "~@/styles/variables";

.showcase-create {
  text-align: left;

  &__added-fields {
    margin-top: 40px;
    padding-top: $gap-m;

    &-row {
      &:not(:first-of-type) {
        border-top: 1px solid $black;
      }
    }
  }
}
</style>
