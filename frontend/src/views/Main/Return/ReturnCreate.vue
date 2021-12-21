<template>
  <showcase-create ref="form" v-bind="createData" @onSend="createReturn" />
</template>

<script>
import ShowcaseCreate from '@/components/Showcase/showcase-create'
import {
  required
} from '@/utils/validation/i18n-validators'
import { useToast } from 'vue-toastification'

export default {
  name: 'ReturnCreate',
  components: {
    ShowcaseCreate
  },
  setup () {
    const toast = useToast()
    return { toast }
  },
  data: () => {
    return {
      createData: {
        title: 'Создать возврат',
        fields: [
          {
            label: 'Номер заказа',
            type: 'select',
            values: [],
            modelValue: 'orderId',
            validation: { required }
          },
          {
            label: 'Номер ТТН',
            type: 'select',
            values: [],
            modelValue: 'ttnId',
            validation: { required }
          },
          {
            label: 'Сотрудник',
            type: 'select',
            values: [],
            modelValue: 'employeeId',
            validation: { required }
          },
          {
            label: 'Дата возврата',
            placeholder: 'Дата возврата',
            type: 'date',
            modelValue: 'returnDate',
            validation: { required }
          },
          {
            label: 'Номер акта возврата',
            placeholder: 'Акт',
            modelValue: 'returnAct',
            validation: { required }
          },
          {
            label: 'Принято',
            modelValue: 'isAccepted',
            type: 'checkbox',
            cols: ['col-auto'],
            validation: { required }
          }
        ]
      }
    }
  },
  created () {
    this.$api.order.getOrdersForUsing()
      .then((data) => {
        this.createData.fields.find(item => item.modelValue === 'orderId').values = data.map(item => {
          return Object.assign({}, {
            text: item.id,
            value: item.id
          })
        })
      })

    this.$api.employee.getEmployee()
      .then((data) => {
        this.createData.fields.find(item => item.modelValue === 'employeeId').values = data.map(item => {
          return Object.assign({}, {
            text: `${item.secondName} ${item.firstName} ${item.thirdName}`,
            value: item.id
          })
        })
      })

    this.$api.ttn.getTTNForUsing()
      .then((data) => {
        this.createData.fields.find(item => item.modelValue === 'ttnId').values = data.map(item => {
          return Object.assign({}, {
            text: item.number,
            value: item.id
          })
        })
      })
  },
  methods: {
    createReturn (data) {
      this.$api.returns.createReturn(data)
        .then(() => {
          this.toast.success('Возврат успешно создан')
          this.$refs.form.clearForm()
        })
        .catch(() => {
          this.toast.error('Ошибка при создании возврата, повторите позже')
        })
    }
  }
}
</script>
