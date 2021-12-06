<template>
  <showcase-create v-bind="createData">
    <showcase-label class="col-md-6" label="Поставщик">
      <select class="form-select" v-model="dataToSend.supplier">
        <option disabled value="">
          Постащик
        </option>
        <option
          v-for="(item, index) in supplierList"
          :key="index"
          :value="item.value"
        >
          {{ item.text }}
        </option>
      </select>
    </showcase-label>

    <showcase-label class="col-md-6" label="ТК">
      <select class="form-select" v-model="dataToSend.tc">
        <option disabled value="">
          ТК
        </option>
        <option
          v-for="(item, index) in tcList"
          :key="index"
          :value="item.value"
        >
          {{ item.text }}
        </option>
      </select>
    </showcase-label>

    <showcase-label class="col-md-6" label="Номер ТТН">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.ttn"
        placeholder="Номер ТТН"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Номер платежного документа">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.paymentDoc"
        placeholder="Номер"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Стоимость поставки">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.supplyCost"
        placeholder="Стоимость"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Дата поставки">
      <input
        class="form-control"
        type="date"
        v-model="dataToSend.supplyDate"
      >
    </showcase-label>

    <showcase-label class="col-md-12" label="Принято">
      <input
        class="form-check-input"
        type="checkbox"
        v-model="dataToSend.accept"
      >
    </showcase-label>

    <showcase-label class="col-md-12" label="Примечание">
      <textarea
        class="form-control"
        v-model="dataToSend.extra"
      ></textarea>
    </showcase-label>

    <showcase-label class="col-md-6" label="Артикул товара">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.art"
        placeholder="Стоимость"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Кол-во">
      <input
        class="form-control"
        type="number"
        v-model="dataToSend.count"
      >
    </showcase-label>

    <showcase-submit>
      Добавить ещё один товар
    </showcase-submit>

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
  name: 'SupplyCreate',
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
        supplier: { required },
        tc: { required },
        ttn: { required },
        paymentDoc: { required },
        supplyCost: { required },
        supplyDate: { required },
        accept: { required },
        extra: { required },
        art: { required },
        count: { required }
      }
    }
  },
  data: () => {
    return {
      createData: {
        title: 'Создать поставку'
      },
      dataToSend: {
        supplier: '',
        tc: '',
        ttn: '',
        paymentDoc: '',
        supplyCost: '',
        supplyDate: '',
        accept: '',
        extra: '',
        art: '',
        count: ''
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
