<template>
  <showcase-create v-bind="createData">
    <showcase-label class="col-md-6" label="Номер">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.number"
        placeholder="Номер"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Дата оформления">
      <input
        class="form-control"
        type="date"
        v-model="dataToSend.issueDate"
        placeholder="01.01.1990"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Тип ТТН">
      <select class="form-select" v-model="dataToSend.ttnType">
        <option disabled value="">
          Тип ТТН
        </option>
        <option
          v-for="(item, index) in ttnType"
          :key="index"
          :value="item.value"
        >
          {{ item.text }}
        </option>
      </select>
    </showcase-label>

    <showcase-label class="col-md-6" label="Форма ТТН">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.ttnForm"
        placeholder="УТП-12"
      >
    </showcase-label>

    <showcase-errors-list
      v-if="v$.$errors.length"
      :errors="v$.$errors"
    />

    <showcase-submit @click="sendToServer">
      <edit-icon />
      Создать
    </showcase-submit>
  </showcase-create>
</template>

<script>
import { useVuelidate } from '@vuelidate/core'
import ShowcaseErrorsList from '@/components/Showcase/showcase-errors-list'
import ShowcaseCreate from '@/components/Showcase/showcase-create'
import ShowcaseLabel from '@/components/Showcase/showcase-label-field'
import ShowcaseSubmit from '@/components/Showcase/showcase-submit-button'
import { EditIcon } from '@iconicicons/vue3'
import {
  required
} from '@/utils/validation/i18n-validators'

export default {
  name: 'AgentCreate',
  components: {
    ShowcaseCreate,
    ShowcaseLabel,
    ShowcaseSubmit,
    ShowcaseErrorsList,
    EditIcon
  },
  setup () {
    return { v$: useVuelidate() }
  },
  validations () {
    return {
      dataToSend: {
        number: { required },
        issueDate: { required },
        ttnType: { required },
        ttnForm: { required }
      }
    }
  },
  data: () => {
    return {
      createData: {
        title: 'Создать ТТН'
      },
      ttnType: [
        {
          text: 'Расход',
          value: 'minus'
        },
        {
          text: 'Приход',
          value: 'plus'
        }
      ],
      dataToSend: {
        number: '',
        issueDate: '',
        ttnType: '',
        ttnForm: ''
      }
    }
  },
  methods: {
    async sendToServer () {
      const isReady = await this.v$.$validate()

      if (!isReady) {
        console.log('Ошибка!')
      } else {
        console.log('Объект готов к отправке', this.dataToSend)
      }
    }
  }
}
</script>
