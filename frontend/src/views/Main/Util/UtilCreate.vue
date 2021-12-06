<template>
  <showcase-create v-bind="createData">
    <showcase-label class="col-md-6" label="Номер ТТН">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.ttnNumber"
        placeholder="Номер ТТН"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Утилизатор">
      <select class="form-select" v-model="dataToSend.utilizator">
        <option disabled value="">
          Утилизатор
        </option>
        <option
          v-for="(item, index) in utilizatorList"
          :key="index"
          :value="item.value"
        >
          {{ item.text }}
        </option>
      </select>
    </showcase-label>

    <showcase-label class="col-md-6" label="Номер акта утилизации">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.actOfUtil"
        placeholder="Номер акта утилизации"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Дата отгрузки">
      <input
        class="form-control"
        type="date"
        v-model="dataToSend.shippingDate"
        placeholder="01.01.1990"
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
        ttnNumber: { required },
        utilizator: { required },
        actOfUtil: { required },
        shippingDate: { required }
      }
    }
  },
  data: () => {
    return {
      createData: {
        title: 'Создать утилизацию'
      },
      utilizatorList: [
        {
          text: 'УтилПро',
          value: 1
        },
        {
          text: 'УтилМакс',
          value: 2
        }
      ],
      dataToSend: {
        ttnNumber: '',
        utilizator: '',
        actOfUtil: '',
        shippingDate: ''
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
