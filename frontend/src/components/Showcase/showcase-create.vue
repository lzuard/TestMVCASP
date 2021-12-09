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
          :class="[
             'col-md-6'
          ]"
          :key="index"
          :label="item.label"
        >
          <input
            v-if="item.type !== 'select'"
            :class="[
             'form-control'
            ]"
            :type="item.type ?? 'text'"
            v-model="dataToSend.modelValue"
            :data-bebra="dataToSend.modelValue"
            :placeholder="item.placeholder"
          />

          <select
            v-else
            class="form-select"
            v-model="dataToSend"
          >
            <option selected disabled>
              {{ item.placeholder }}
            </option>
            <option
              v-for="(selectItem, index) in item.values"
              :key="index"
              :value="selectItem.value"
            >
              {{ selectItem.text }}
            </option>
          </select>
        </showcase-label-field>

<!--        <showcase-errors-list-->
<!--          v-if="v$.$errors.length"-->
<!--          :errors="v$.$errors"-->
<!--        />-->

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
// import { required } from '@/utils/validation/i18n-validators'

export default {
  name: 'showcase-create',
  components: {
    ShowcaseLabelField,
    ShowcaseSubmit,
    ShowcaseTitle,
    EditIcon
  },
  setup () {
    return { v$: useVuelidate() }
  },
  validations () {
    return {
      dataToSend: {}
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
  emits: ['onSend'],
  methods: {
    async onSend () {
      const isReady = await this.v$.$validate()

      if (!isReady) {
        console.log('Ошибка!')
      } else {
        this.$emit('onSend', this.dataToSend)
      }
    }
  }
}
</script>

<style>
.showcase-create {
  text-align: left;
}
</style>
