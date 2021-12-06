<template>
  <showcase-create v-bind="createData">
    <showcase-label class="col-md-6" label="Номер ТТН заказа">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.ttnOrder"
        placeholder="Номер ТТН заказа"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Дата возврата">
      <input
        class="form-control"
        type="date"
        v-model="dataToSend.returnDate"
        placeholder="01.01.1990"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Номер ТТН возврата">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.ttnReturn"
        placeholder="Номер ТТН возврата"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Номер акта возврата">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.actOfReturn"
        placeholder="Номер акта возврата"
      >
    </showcase-label>

    <showcase-label class="col-12" label="Принято">
      <input
        class="form-check-input"
        type="checkbox"
        v-model="dataToSend.accept"
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
  name: 'ReturnCreate',
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
        ttnOrder: { required },
        returnDate: { required },
        ttnReturn: { required },
        actOfReturn: { required }
      }
    }
  },
  data: () => {
    return {
      createData: {
        title: 'Создать возврат'
      },
      dataToSend: {
        ttnOrder: '',
        returnDate: '',
        ttnReturn: '',
        actOfReturn: '',
        accept: false
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
